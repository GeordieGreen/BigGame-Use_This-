using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 20f;
    public float waitTime = 1f;
    private float currentWait = 0f;

    float minX;
    float maxX;
    float minZ;
    float maxZ;
    Vector3 moveSpot;

    // Start is called before the first frame update
    void Start()
    {
        GroundSize();
        moveSpot = GetNewPos();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }

    void GroundSize()
    {
        GameObject ground = GameObject.FindWithTag("Ground");
        Renderer gScale = ground.GetComponent<Renderer>();
        minX = (gScale.bounds.center.x - gScale.bounds.extents.x);
        maxX = (gScale.bounds.center.x + gScale.bounds.extents.x);
        minZ = (gScale.bounds.center.z - gScale.bounds.extents.z);
        maxZ = (gScale.bounds.center.z + gScale.bounds.extents.z);
    }
    Vector3 GetNewPos()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 newPos = new Vector3(randomX, transform.position.y, randomZ);
        return newPos;
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpot) <= 0.2f)
        {
            if (currentWait <= 0)
            {
                moveSpot = GetNewPos();
                currentWait = waitTime;
            }
            else
            {
                currentWait = Time.deltaTime;
            }
        }
    }

    void Rotation()
    {
        Vector3 targetDir = moveSpot - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.5f, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
