using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesDesvanecientes : MonoBehaviour
	{
		public Light myLight;
		public float OriginalIntensity;
		public bool Dentro;
		public float multiplicar;
		void Start()
		{
			
			OriginalIntensity= myLight.intensity;
		}

		void Update()
		{
			if(Dentro)
			{
				IntensityDown();
			}
			if (!Dentro)
			{
				RestoreIntensity();
			}
		}
		// OnTriggerEnter is called when the Collider other enters the trigger.
		private void OnTriggerEnter(Collider other)
		{
			Dentro = true;
		}
		// OnTriggerExit is called when the Collider other has stopped touching the trigger.
		private void OnTriggerExit(Collider other)
		{
			Dentro = false;
		}
		void IntensityDown()
		{
			myLight.intensity = (myLight.intensity - multiplicar * Time.deltaTime );
			if (myLight.intensity < 0)
			{
				myLight.intensity = 0;
			}
		}
		void RestoreIntensity()
		{
			
			myLight.intensity = OriginalIntensity;
		}
	}

