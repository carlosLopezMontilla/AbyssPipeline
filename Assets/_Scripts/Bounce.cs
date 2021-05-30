using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject particleSystem;
    public bool isBouncing;
    public float countdown, countdownTime;
    public GameObject spawner;
    
    void Start()
    {
        
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
        countdownTime -= Time.deltaTime;   
        if(countdownTime <= 0f)
        {
            GameObject effectParticles = Instantiate(particleSystem, new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.identity);
            print(effectParticles.name);
            countdownTime = countdown;
            isBouncing = false;
            //StartCoroutine(stopParticles());
        }
    }

   /* IEnumerator stopParticles()
    {
        yield return new WaitForSeconds(countdown);
        isBouncing = false;
        
    }*/
}

