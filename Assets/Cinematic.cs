using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematic : MonoBehaviour
{
	public PlayableDirector timeline;
	public Rigidbody player;
	
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
		player.constraints = RigidbodyConstraints.FreezeAll;
		yield return new WaitForSeconds(7.5f);
		player.constraints = RigidbodyConstraints.FreezeRotation;
	}
}
