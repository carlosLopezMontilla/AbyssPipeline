using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickUp : MonoBehaviour
{
    public GameManager gameManager;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            gameManager.coralCollected++;
            Destroy(this.gameObject);
        }
    }


}
