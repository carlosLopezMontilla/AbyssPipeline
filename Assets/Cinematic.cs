using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematic : MonoBehaviour
{
	public PlayableDirector timeline;
	public Rigidbody player;
	public float timer;
	public Jump noJump;
	public GameObject show;
	public GameObject HUD;
	
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
	        timeline.Play();   
	        StartCoroutine(noMove());
        }
    }

	IEnumerator noMove()
	{
        player.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		noJump.enabled = false;
		HUD.SetActive(false);
        yield return new WaitForSeconds(timer);
        player.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        noJump.enabled = true;
		HUD.SetActive(true);
		show.SetActive(true);
        Destroy(this);
    }
}
