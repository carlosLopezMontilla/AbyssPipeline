using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Light light;
    public float currentIntensity, maxIntensity = 5f, initialIntensity = 0f, recoveryTime = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            light.intensity = maxIntensity;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            light.intensity = initialIntensity;
        } 
    }
  

}
