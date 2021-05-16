using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Transform player;
    public bool isBouncing;
    public PlayerController pCont;
    public Vector3 direction = new Vector3();
    public float bounceDirection;
    public Vector3 playerContact = new Vector3();
    

    private void Start()
    {
        isBouncing = false;
    }

    private void Update()
    {
        if (isBouncing)
        {
            pCont.Rebound();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            isBouncing = true;
            ContactPoint contact = collision.contacts[0];
            direction = contact.point;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            isBouncing = false;
        }
    }
}

