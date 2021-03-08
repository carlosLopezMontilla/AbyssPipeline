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

    [Header("Hold to jump")]
	public float chargePower = 0;
	public float initialPower;
    public float Force = 100;
    private bool jumpNow = false;
	public float jumpLimit;
    public bool isGrounded;
    public bool jumpPressed;
    
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
        isGrounded = true;
	    jumpPressed = false;
        isCrouched = false;
	    speed = OriginalSpeed;
	    initialPower = chargePower;
        distanceToGround = transform.localScale.y;
            
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
       
        isGrounded = Physics.Raycast(ray, distanceToGround, LayerMask.GetMask("Ground"));
        
  
       if(Input.GetKey(KeyCode.LeftShift) && habs.hideUnlock == true)
        {
            isCrouched = true;
        }else
        {
            isCrouched = false;
        }

       

        if (isGrounded && Input.GetKey(KeyCode.Space) && jumpPressed == false)
        {
            anim.SetBool("IsGrounded", true);
	        chargePower +=  Time.deltaTime;
            if (chargePower >= jumpLimit)
            {

                holdToJump();

            }
	        
            
        }
        if(Input.GetKeyUp(KeyCode.Space) && jumpPressed == false)
        {
            jumpPressed = true;
            jumpNow = true;
            
        }
        
        if(isGrounded)
        {
            jumpPressed = false;
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
        jumpPressed = true;
        chargePower = initialPower;
       
    }






}
