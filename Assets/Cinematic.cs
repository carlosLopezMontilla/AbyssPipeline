using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematic : MonoBehaviour
{
    public PlayableDirector timeline;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timeline.Play();    
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
