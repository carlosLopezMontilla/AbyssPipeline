using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
	public SpriteRenderer FrontGround;
	public bool Inside;
	Color c;
    // Start is called before the first frame update
    void Start()
	{ 

    }

    // Update is called once per frame
    void Update()
    {
	    if(Inside)
	    {
	    	Alpha();
	    }
	    if(!Inside)
	    {
	    	Restore();
	    }
    }

	// OnTriggerEnter is called when the Collider other enters the trigger.
	private void OnTriggerEnter(Collider other)
	{
  Inside = true;
	}
	// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	private void OnTriggerExit(Collider other)
	{
		Inside = false;
	}
	void Alpha()
	{
	
		Color c = FrontGround.GetComponent<SpriteRenderer>().material.color;
		c.a -= 0.3f * Time.deltaTime;
		if(c.a <= 0.1f)
			{
			c = new Color (0f,0f,0f,0f);
			}	
		FrontGround.GetComponent<SpriteRenderer>().material.color = c;
		
	}
	void Restore()
	{
		Color c = FrontGround.GetComponent<SpriteRenderer>().material.color;
		c.a +=0.3f;
		if(c.a >= 1f)
		{
			c = new Color (1f,1f,1f,1f);
		}	
		FrontGround.GetComponent<SpriteRenderer>().material.color = c;
	}
}
