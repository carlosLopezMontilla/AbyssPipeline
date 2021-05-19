using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public bool zoomActive = false;
	public float distance;
	public Transform Cam;
	public float Speed;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
			zoomActive = true; 
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
			zoomActive = false;
	}
	
	
	public void Update()
	{
		Vector3 CamPosition = new Vector3(Cam.position.x, Cam.position.y, Cam.position.z);
		
		if(zoomActive){
			Cam.transform.position = Vector3.Lerp(CamPosition, CamPosition + new Vector3 (0,0,distance), Speed * Time.deltaTime);

		}
		else{
			Cam.transform.position = Vector3.Lerp(CamPosition, CamPosition + new Vector3 (0,0,-distance), Speed * Time.deltaTime);

		}
	}
}
