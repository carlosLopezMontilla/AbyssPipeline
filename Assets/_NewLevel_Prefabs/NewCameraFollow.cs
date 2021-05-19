using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
	public Transform player;
	public float x;
	public float y;
	public float z;

	void Update()
	{


		transform.position = new Vector3(player.position.x, player.position.y, player.position.z) + new Vector3(x,y,z);
                
		
	}
}
