﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Analisis : MonoBehaviour
{
	[Header("Analyze")]
    public GameObject text;
	public GameObject Analyze;
    public GameObject Exit;
	public SphereCollider sColl;
	public bool Inside, inAnalyze;
	//public bool Analyzed;
	public UnlockHabs habs;

	public EnemyChase eChase;
    // Start is called before the first frame update
    void Start()
    {
	    Inside = false;
		sColl = GetComponent<SphereCollider>();
		eChase = GetComponent<EnemyChase>();
		sColl.radius = eChase.vision;
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
			if (Input.GetKey(KeyCode.L))
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
   
	
