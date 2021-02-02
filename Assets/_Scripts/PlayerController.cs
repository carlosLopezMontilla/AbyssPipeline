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

    [Header("Hold to jump")]
	public float chargePower = 0;
	public float initialPower;
    public float Force = 100;
    private bool jumpNow = false;
    public int jumpLimit;
    public float gravity;
    public bool isGrounded;
    bool jumpPressed;

    [Header("Crouch")]
    public bool isCrouched;

   
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
	    jumpPressed = false;
        isCrouched = false;
	    speed = OriginalSpeed;
	    initialPower = chargePower;
    
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, 1.02f, LayerMask.GetMask("Ground"));

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isCrouched = true;
        }else
        {
            isCrouched = false;
        }
       


        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
	        chargePower +=  Time.deltaTime;
            if(chargePower >= jumpLimit)
            {
                holdToJump();
            }
	        
            
        }
        if(Input.GetKeyUp(KeyCode.Space) && isCrouched == false)
        {
            jumpNow = true;
        }
    }

   
    void FixedUpdate()
    {
	    moveInput = Input.GetAxisRaw("Horizontal");
        
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
        if (isCrouched == false)
        {
            rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);
        }
        if (jumpNow)
        {
            holdToJump();
        }
        
    }

    void holdToJump()
    { 
                rb.AddForce(Vector3.up * chargePower * Force, ForceMode.Impulse);
                jumpNow = false;
	    chargePower = initialPower;
    }
    
  



}
