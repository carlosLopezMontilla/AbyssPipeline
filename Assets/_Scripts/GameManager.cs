using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [Header("Collectibles")]
    public int coralCollected;
    public TextMeshProUGUI coral;
	public PlayableDirector timeline;
	public Rigidbody player;
	public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        coralCollected = 0;
    }

    void Update()
    {
        coral.text = coralCollected.ToString();
        if(coralCollected == 10)
        {
        	Destroy(message);
	        timeline.Play();
	        coralCollected = 0;
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
