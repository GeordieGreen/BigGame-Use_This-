using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody rb;
    public float upForce = 5f;

    bool inWater = false; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (inWater == true)
        {
            Vector3 force = Vector3.up * upForce;
            rb.AddForce(force, ForceMode.Acceleration);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            inWater = true;
            rb.drag = 3f;
            upForce = 20f;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            inWater = false;
            rb.drag = 0f;
            upForce = 6f;
        }
    }
}
