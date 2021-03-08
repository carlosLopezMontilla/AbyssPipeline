﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public int maxFOV, initialFOV, recoverySpeed;
    public float currentFOV;

    private void Start()
    {
        cam.fieldOfView = initialFOV;
    }
     void Update()
    {
        currentFOV = cam.fieldOfView;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            CamaraZoomUp();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CamaraZoomDown();
    }
    private void CamaraZoomUp()
    {
        cam.fieldOfView += 1 * Time.deltaTime;
       if(cam.fieldOfView >= maxFOV)
        {
            cam.fieldOfView = maxFOV;
        }
    }
    void CamaraZoomDown()
    {
        cam.fieldOfView = initialFOV;
    }
}