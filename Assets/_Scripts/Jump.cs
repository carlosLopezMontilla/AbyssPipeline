using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool isGrounded;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float distanceToGround;
    public Rigidbody rb;
    public float jumpForce;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(feetPos.transform.position, Vector3.down);

        isGrounded = Physics.Raycast(ray, distanceToGround, LayerMask.GetMask("Ground"));
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping =true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector3.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter >0 && isJumping == true)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            { 
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            
            isJumping = false;
        }
    }
}
