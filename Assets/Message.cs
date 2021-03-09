using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
	public TextMeshProUGUI msg;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			msg.gameObject.SetActive(true);
		}
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			msg.gameObject.SetActive(false);
		}
	}
}
