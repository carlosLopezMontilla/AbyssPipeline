using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject effect;
    public bool isBouncing;
    public float countdown, countdownTime;
    void Start()
    {
        effect.SetActive(false);
        isBouncing = false;
        countdownTime = countdown;
    }

    private void Update()
    {
        if(isBouncing)
        {
            ParticlesActives();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isBouncing = true;
    }

    void ParticlesActives()
    {
        effect.SetActive(true);
        countdownTime -= Time.deltaTime;   
        if(countdownTime <= 0f)
        {
            countdownTime = countdown;
            StartCoroutine(stopParticles());
        }
    }

    IEnumerator stopParticles()
    {
        yield return new WaitForSeconds(countdown);
        isBouncing = false;
        effect.SetActive(false);
    }
}

