using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHide : MonoBehaviour
{

    public bool unlockHide;
    void Start()
    {
        unlockHide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            unlockHide = true;
        }
    }
}
