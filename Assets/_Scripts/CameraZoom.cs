using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public int maxFOV, initialFOV, recoverySpeed;
    public float currentFOV;
    public bool fuera;
    public TextMeshProUGUI zoneText;
    public GameObject zone;

    private void Start()
    {
        cam.fieldOfView = initialFOV;
        zoneText.text = "buena referencia";
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
            zone.SetActive(true);
            CamaraZoomUp();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        fuera = true;
    }
    private void CamaraZoomUp()
    {
        cam.fieldOfView += recoverySpeed * Time.deltaTime;
       if(cam.fieldOfView >= maxFOV)
        {
            cam.fieldOfView = maxFOV;
        }
    }
    void CamaraZoomDown()
    {
        cam.fieldOfView -= recoverySpeed * Time.deltaTime;
        if(cam.fieldOfView <= initialFOV)
        {
            cam.fieldOfView = initialFOV;
            fuera = false;
            Destroy(this.gameObject);
        }
    }
}
