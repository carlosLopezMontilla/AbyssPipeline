using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Analisis : MonoBehaviour
{
	[Header("Gameobject References")]
    public GameObject text;
	public GameObject Analyze;
    public GameObject Exit;
	[Header("Colliders")]
	public SphereCollider sColl;

	[Header("Booleanos")]
	public bool Inside, inAnalyze;

	[Header("Scripts References")]
	public UnlockHabs habs;


	
    void Start()
    {
	    Inside = false;
		sColl = GetComponent<SphereCollider>();
	
		//Analyzed = false;

    }

    // Update is called once per frame
    void Update()
	{
		if( Inside)
		{
			if (Input.GetKey(KeyCode.E))
				Analizador();
		
	    }

        if (inAnalyze)
        {
			if (Input.GetMouseButton(0))
			{
				SalirAnalizador();
			}

        }

	}

    private void OnTriggerEnter(Collider other)
	{
		Inside = true;
	    text.SetActive(true);
	    
    }
	// OnTriggerStay is called once per frame for every Collider other that is touching the trigger.
	
    private void OnTriggerExit(Collider other)
	{
		Inside = false;
	    text.SetActive(false);
    }

	void Analizador()
    {
		Time.timeScale = 0f;
		text.SetActive(false);
		Analyze.SetActive(true);
		Exit.SetActive(true); 
		inAnalyze = true;
		habs.hideUnlock = true;
		
		//Analyzed = true;
	}

	void SalirAnalizador()
    {
		Time.timeScale = 1f;
		Analyze.SetActive(false);
		text.SetActive(false);
		Exit.SetActive(false);
		sColl.isTrigger = false;
		sColl.radius = 0;
	}

    }
   
	

