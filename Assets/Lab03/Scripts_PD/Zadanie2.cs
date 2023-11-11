using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.position.x > 10)
        {
            rb.Sleep();
            rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
            Debug.Log("went over x = 10");
            
        }
        if(transform.position.x <= 0)
        {
            rb.Sleep();
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
            Debug.Log("went under x=0");
        }
    }
}
