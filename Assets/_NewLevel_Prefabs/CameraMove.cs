using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public bool zoomActive = false;
	public Vector3[] Target;
	public GameObject Cam;
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
		if(zoomActive){
			Cam.transform.position = Vector3.Lerp(Cam.transform.position,Target[1],Speed*Time.deltaTime);
		}
		else{
			Cam.transform.position = Vector3.Lerp(Cam.transform.position,Target[0],Speed*Time.deltaTime);			
		}


	}
}
