using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform other;
	public float  speed;
	public float vision;
	public float VisionAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	    transform.position += Vector3.left * speed * Time.deltaTime;
        
        Vector3 displacement = other.position - transform.position;

	    float range = displacement.magnitude;
        float EnemyVision = VisionAngle / 2;
	    float EnemyAngle = Vector3.Angle(Vector3.left, displacement);
        
	    transform.position += -transform.right * speed * Time.deltaTime;
	    if (range < vision && range < vision && EnemyVision > EnemyAngle  )
	        transform.position = Vector3.MoveTowards(transform.position, other.position, speed * Time.deltaTime);
            
    }
	// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	protected void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,vision);
		
		Gizmos.color = Color.red;
		Gizmos.DrawLine(other.position, transform.position);
		
		
		
		
	}

}
