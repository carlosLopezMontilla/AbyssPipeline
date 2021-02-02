using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public Transform other;
	
	public float  speed;
	public float approachSpeed;
	public float followSpeed;
	public float vision;
	public float VisionAngle;
	

	public PlayerController pContr;
    // Start is called before the first frame update
    void Start()
    {
		approachSpeed = speed / 2;
		followSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += Vector3.left * speed * Time.deltaTime;
		
		Vector3 displacement = player.position - transform.position;

	    float range = displacement.magnitude;
        float EnemyVision = VisionAngle / 2;
	    float EnemyAngle = Vector3.Angle(Vector3.left, displacement);


		if (pContr.isCrouched == true)
			transform.position += Vector3.left * 0 *Time.deltaTime;

		if (pContr.isCrouched == false && range < vision && range < vision && EnemyVision > EnemyAngle)
				transform.position = Vector3.MoveTowards(transform.position, player.position, approachSpeed * Time.deltaTime);
		
	}
	// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	protected void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,vision);
		
		Gizmos.color = Color.red;
		Gizmos.DrawLine(player.position, transform.position);

		
	}
	
}
