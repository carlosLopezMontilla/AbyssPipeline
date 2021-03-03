using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        coral.text = coralCollected.ToString();
    }
}
