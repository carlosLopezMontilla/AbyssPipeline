using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockClimb : MonoBehaviour
{
    public bool unlockClimb;
    void Start()
    {
        unlockClimb = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            unlockClimb = true;
        }
    }
}
