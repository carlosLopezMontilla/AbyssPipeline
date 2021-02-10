using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHabs : MonoBehaviour
{
	public bool hideUnlock;
    public EnemyChase enemy;
    public PlayerController pContr;
    public Transform player;
    Vector3 lookDirection = Vector3.left;
    void Start()
	{
		hideUnlock = false;
	}

    private void Update()
    {
        if(hideUnlock == true)
        {
           

            Vector3 displacement = player.position - transform.position;

            float range = displacement.magnitude;
            float EnemyVision = enemy.VisionAngle / 2;
            float EnemyAngle = Vector3.Angle(lookDirection, displacement);
            

            if (pContr.isCrouched == true)
                transform.position += Vector3.left * 0 * Time.deltaTime;

            if (pContr.isCrouched == false && range < EnemyVision && range < enemy.vision && EnemyVision > EnemyAngle)
                transform.position = Vector3.MoveTowards(transform.position, player.position, enemy.approachSpeed * Time.deltaTime);
        }
    }
}
