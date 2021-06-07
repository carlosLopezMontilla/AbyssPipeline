using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHabs : MonoBehaviour
{
    public int currentHab;
    [Header("Hide")]
	public bool hide;
    public PlayerController pContr;
    public Transform player;
    Vector3 lookDirection = Vector3.left;

    [Header("Climb")]
    public float climbSpeed;
    public bool isClimbing;
    public float v;

    [Header("Lanntern")]
    public GameObject linterna;
    public bool isLighting;
    

    void Start()
	{
		hide = false;
        isClimbing = false;
	}

    private void Update()
    {
        Lantern();
        Climbing();
        Hide();
    }
   void Hide()
    {
        currentHab = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.GetComponent<PlayerController>().enabled = false;
            pContr.anim.SetFloat("moveInput", 0);
            pContr.anim.SetTrigger("hide");
            hide = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.GetComponent<PlayerController>().enabled = true;
            pContr.anim.SetFloat("moveInput", pContr.moveInput);
            hide = false;
        }

    }


    void Climbing()
    {
        float v = Input.GetAxis("Vertical");
        if (pContr.isClimbing)
        {
            pContr.anim.SetFloat("Climb", v);
            if (v > 0.2)
            {
                pContr.rb.velocity = Vector3.up * climbSpeed;
                
            }
            
        }
        else
        {
            pContr.anim.SetTrigger("Idle");
        }
    }

    void Lantern()
    {
        currentHab = 2;

        if (Input.GetKey(KeyCode.L))
        {
            linterna.SetActive(true);
            isLighting = true;
           
        }

    }
}
/* Vector3 displacement = player.position - transform.position;

            float range = displacement.magnitude;
            float EnemyVision = enemy.VisionAngle / 2;
            float EnemyAngle = Vector3.Angle(lookDirection, displacement);*/
