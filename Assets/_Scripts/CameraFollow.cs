using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
    public float smoothing;
    public Vector2 minPosition, maxPosition;

     void LateUpdate()
    {
       if(transform.position != player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            targetPosition.y = Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
                
        }
    }
}
