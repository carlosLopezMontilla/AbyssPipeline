using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom2 : MonoBehaviour
{
    public CameraFollow2 isZoom;
    public Vector3 zoomPos;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isZoom.zoomActive = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isZoom.zoomActive = false;
        }
    }
}
