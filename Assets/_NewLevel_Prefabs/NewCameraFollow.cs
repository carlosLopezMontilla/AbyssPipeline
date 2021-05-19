using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
	public CameraZoomNew zoom;
	public Transform player;

	public void Update()
	{

		transform.position = new Vector3(player.position.x, player.position.y, player.position.z) + new Vector3(zoom.x,zoom.y,zoom.z);
                
	}
	
	
}
