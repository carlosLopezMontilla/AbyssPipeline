using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
	
	public float approachSpeed;
	public float vision;
	public float VisionAngle;

	public Vector3 lookDirection = Vector3.left;

	public PlayerController pContr;
	public UnlockHabs habs;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
     void Update()
    {
		Vector3 displacement = player.position - transform.position;
		
		float range = displacement.magnitude;
		float EnemyVision = VisionAngle / 2;
		float EnemyAngle = Vector3.Angle(lookDirection, displacement);
		if (habs.hide == false && range < EnemyVision && range < vision && EnemyVision > EnemyAngle)
			transform.position = Vector3.MoveTowards(transform.position, player.position, approachSpeed * Time.deltaTime);
	}
	protected void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,vision);
		
		Gizmos.color = Color.red;
		Gizmos.DrawLine(player.position, transform.position);

		
	}
	
}
	

