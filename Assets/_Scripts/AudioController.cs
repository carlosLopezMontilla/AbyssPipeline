using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public AudioSource secret;

	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			secret.Play();
			Destroy(this);
		}
	}
	
}
