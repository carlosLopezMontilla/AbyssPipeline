using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject[] particles;
    public bool isBouncing;
    public float countdown, countdownTime;
    public GameObject spawner;
    public int id;
    
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
        id = (int)Random.Range(0, particles.Length);
        print(id);
    }
   

    void ParticlesActives()
    {         
        countdownTime -= Time.deltaTime;   
        if(countdownTime <= 0f)
        {
            GameObject effectParticles = Instantiate(particles[id], new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.identity);
            countdownTime = countdown;
            isBouncing = false;
            Destroy(effectParticles, 1.5f);
            //StartCoroutine(stopParticles());
        }
    }

   /* IEnumerator stopParticles()
    {
        yield return new WaitForSeconds(countdown);
        isBouncing = false;
        
    }*/
}

