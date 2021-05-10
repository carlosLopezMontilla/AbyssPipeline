using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public int maxFOV, initialFOV, recoverySpeed;
    public float currentFOV;
    public bool fuera;

    private void Start()
    {
        cam.fieldOfView = initialFOV;
    }
     void Update()
    {
        currentFOV = cam.fieldOfView;
        if(fuera)
        {
            CamaraZoomDown();
        }
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
        fuera = true;
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
        cam.fieldOfView -= 1 * Time.deltaTime;
        if(cam.fieldOfView <= initialFOV)
        {
            cam.fieldOfView = initialFOV;
            fuera = false;
        }
    }
}
