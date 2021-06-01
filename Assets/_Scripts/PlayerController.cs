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

    [Header("Crouch")]
	public bool isCrouched;
    
	[Header("Analisis")]
	public Analisis analisis;

    [Header("Habilidades")]
    public UnlockHabs habs;

    [Header("Animaciones")]
    public Animator anim;

    [Header("Climb")]
    public bool isClimbing;
    public float climbSpeed;

    [Header("Rebound")]
    public Bounce bounce;
    public float bounceSpeed;

    [Header("Linterna")]
    public GameObject linterna;
    public bool isLighting;

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
        Lantern();
        Climbing();
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
            anim.SetFloat("moveInput", moveInput);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 90);
            anim.SetFloat("moveInput", moveInput);
        }
        if (isCrouched == false)
        {
            rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);
        }

        if(isClimbing)
        {
            Climbing();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Climb"))
        isClimbing = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isClimbing = false;
    }

    void Climbing()
    {
        float v = Input.GetAxis("Vertical");
      
        if (v > 0)
        {
	        rb.velocity = Vector3.up * climbSpeed;
        }
    }

    void Lantern()
    {
        if(Input.GetKey(KeyCode.F))
        {
            linterna.SetActive(true);
            isLighting = true;
        }
        
    }
}
