using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestination : MonoBehaviour
{

    public float xPosition;
    public float zPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            xPosition = Random.Range(-30, 30);
            zPosition = Random.Range(-45, 45);

            this.gameObject.transform.position = new Vector3(xPosition, 23, zPosition);
        }
    }
}
