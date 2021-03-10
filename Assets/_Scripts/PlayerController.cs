using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody rb;
    public float speed;
    private float moveInput;
	public float YjumpForce;
	public float acceleration;
	public float maxSpeed;
	public float OriginalSpeed;
    public float distanceToGround;

    /*[Header("Hold to jump")]
	public float chargePower = 0;
	public float initialPower;
    public float Force = 100;
    private bool jumpNow = false;
	public float jumpLimit;
    public bool isGrounded;
    public bool jumpPressed;
    public Transform feetPos;
    public float checkRadius;*/
    
    [Header("Crouch")]
	public bool isCrouched;
    
	[Header("Analisis")]
	public Analisis analisis;

    [Header("Habilidades")]
    public UnlockHabs habs;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        isCrouched = false;
	    speed = OriginalSpeed;
	    
        distanceToGround = 0.05f;
            
    }
    void Update()
    {
       
  
       if(Input.GetKey(KeyCode.LeftShift) && habs.hideUnlock == true)
        {
            isCrouched = true;
        }else
        {
            isCrouched = false;
        }

    }


    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");


        anim.SetFloat("moveInput", moveInput);
        if (moveInput != 0)
        {
            speed += acceleration;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }

        else
        {
            speed = OriginalSpeed;
        }
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 90);
        }




        if (isCrouched == false)
        {
            rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);
        }

    }
}
