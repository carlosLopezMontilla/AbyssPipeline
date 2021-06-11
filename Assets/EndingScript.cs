using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingScript: MonoBehaviour
{
	public Rigidbody player;
	public Jump noJump;
	public GameObject HUD;
	public GameObject EndScreen;
	
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
	        player.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
	        noJump.enabled = false;
	        HUD.SetActive(false);
	        EndScreen.SetActive(true);
        }
    }
}
