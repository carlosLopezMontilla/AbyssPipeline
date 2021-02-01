using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretZone : MonoBehaviour
	{
		[Header ("Secret Zone")]
		Camera m_Cameramain;
		// Start is called before the first frame update
		void Start()
		{
			m_Cameramain = Camera.main;
			m_Cameramain.cullingMask = -1;
		}

		// Update is called once per frame
		void Update()
		{
        
		}
		private void OnTriggerEnter(Collider other)
		{
			m_Cameramain.cullingMask = LayerMask.GetMask("Player") | LayerMask.GetMask("Ground");
		}
	
		// OnTriggerExit is called when the Collider other has stopped touching the trigger.
		private void OnTriggerExit(Collider other)
		{
			m_Cameramain.cullingMask = -1; 
		}
	}
