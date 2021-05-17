using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private void Start()
    { 
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ; 
        rb.useGravity = false;
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            speed = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            speed = 1;
        }
    }

 
}
