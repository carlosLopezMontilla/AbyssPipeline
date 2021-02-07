using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public Transform other;
	
	public float approachSpeed;
	public float followSpeed;
	public float vision;
	public float VisionAngle;

	public List<Transform> points;
	public int nextID = 0;
	int idChangeValue = 1;
	public float speed;



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
		MoveToNextPoint();
		
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
	void MoveToNextPoint()
	{
		Transform goalPoins = points[nextID];
		if (goalPoins.transform.position.x > transform.position.x)
			transform.localScale = new Vector3(1, 1, -1);
		else 
			transform.localScale = new Vector3(1, 1, 1);

		transform.position = Vector3.MoveTowards(transform.position,goalPoins.position,speed * Time.deltaTime);
		if(Vector3.Distance(transform.position,goalPoins.position)<1f)
		{
			if (nextID == points.Count - 1)
				idChangeValue = -1;

			if (nextID == 0)
				idChangeValue = 1;

			nextID += idChangeValue;
		}

	}
}
