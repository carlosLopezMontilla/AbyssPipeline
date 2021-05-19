using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomNew : MonoBehaviour
{

	public float z = -37;
	public float y = 4;
	public float x = 0;
	public bool zoomActive = false;
	public float zoomAmountZ;
	public float zoomAmountX;
	public float zoomAmountY;
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
		if(zoomActive)
		{
			z = Mathf.Lerp(z,zoomAmountZ, Speed * Time.deltaTime);
			y = Mathf.Lerp(y,zoomAmountY, Speed * Time.deltaTime);
			x = Mathf.Lerp(x,zoomAmountX, Speed * Time.deltaTime);

		}
		else
		{
			z = Mathf.Lerp(z,-37, Speed * Time.deltaTime);
			y = Mathf.Lerp(y,4, Speed * Time.deltaTime);
			x = Mathf.Lerp(x,0, Speed * Time.deltaTime);
		}
				
	}
}
