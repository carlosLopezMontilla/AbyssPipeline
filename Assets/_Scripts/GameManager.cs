using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [Header("Collectibles")]
    public int coralCollected;
    public TextMeshProUGUI coral;
    // Start is called before the first frame update
    void Start()
    {
        coralCollected = 0;
    }

    void Update()
    {
	    coral.text = "Has encontrado " + coralCollected.ToString() + " de 2 conchas secretas";
    }
   
}
