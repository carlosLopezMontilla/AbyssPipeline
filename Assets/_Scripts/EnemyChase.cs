using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
	
	public float approachSpeed;
	public float followSpeed;
	public float vision;
	public float VisionAngle;
	public float currentVisionAngle;

	public List<Transform> points;
	public int nextID = 0;
	int idChangeValue = 1;
	public float speed;

	public GameObject parentObject;
	Vector3 lookDirection = Vector3.left;

	public PlayerController pContr;
	public UnlockHabs habs;
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
	
	}
	// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	/*protected void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,vision);
		
		Gizmos.color = Color.red;
		Gizmos.DrawLine(player.position, transform.position);

		
	}*/
	void MoveToNextPoint()
	{
		Transform goalPoins = points[nextID];
		if (goalPoins.transform.position.x > transform.position.x)
		{
			transform.localScale = new Vector3(-1,1,1);
			parentObject.transform.localScale = new Vector3(-1,1,1);
			lookDirection = Vector3.right;
		}
		else
		{
			transform.localScale = new Vector3(1, 1, 1);
			parentObject.transform.localScale = new Vector3(1, 1, 1);
			lookDirection = Vector3.left;
		}

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
