using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockHabs : MonoBehaviour
{
    public int currentHab;
    public int activeHab;
    public GameObject hideSelect, climbSelect;
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
        currentHab = 1;
        hideSelect.SetActive(true);
        climbSelect.SetActive(false);
        activeHab = currentHab;
		hide = false;
        isClimbing = false;
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            activeHab -= 1;
            hideSelect.SetActive(true);
            climbSelect.SetActive(false);
            if (activeHab < 1)
            {
                activeHab = 1;
            }

        }
            if(Input.GetKeyDown(KeyCode.E))
            {
            activeHab += 1;
            hideSelect.SetActive(false);
            climbSelect.SetActive(true);
            if(activeHab > 2 )
            {
                activeHab = 2;
            }

        }
        
       
        
        if(activeHab == 1)
        {
           Hide();

        }
        if (activeHab == 2)
        {
            Climbing();
        }

    }
   void Hide()
    {

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
        currentHab = 1;
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
