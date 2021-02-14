using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	public static AudioController instance;
	
	public AudioSource secret;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		instance = this;
	}
	
	public void PlaySecretZone()
	{
		secret.Stop();
		secret.Play();
	}
}
