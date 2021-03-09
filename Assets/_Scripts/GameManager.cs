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
    public PlayableDirector timeline;
    // Start is called before the first frame update
    void Start()
    {
        coralCollected = 0;
    }

    void Update()
    {
        coral.text = coralCollected.ToString();
        if(coralCollected == 10)
        {
            timeline.Play();
        }
    }
}
