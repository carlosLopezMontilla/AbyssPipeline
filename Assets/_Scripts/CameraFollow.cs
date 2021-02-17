using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
    public float smoothing;
    public Vector3 highPosition;

     void Update()
    {
       if(transform.position != player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y + highPosition.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
                
        }
    }
}
