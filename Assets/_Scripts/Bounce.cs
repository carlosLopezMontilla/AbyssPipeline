using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Light light;
    public float currentIntensity, maxIntensity = 5f, initialIntensity = 0f, recoveryTime = 0.1f;

    private void Update()
    {
        if (light.intensity == maxIntensity)
        {
            currentIntensity = Mathf.MoveTowards(maxIntensity, initialIntensity, Time.deltaTime);
            light.intensity = currentIntensity;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            light.intensity = maxIntensity;
        }
    }



}
