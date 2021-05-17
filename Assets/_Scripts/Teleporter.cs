using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	public Transform tpTarget;
	public GameObject Player;
	
	void OnTriggerEnter(Collider other)
	{
		Player.transform.position = tpTarget.transform.position;		
	}
}
