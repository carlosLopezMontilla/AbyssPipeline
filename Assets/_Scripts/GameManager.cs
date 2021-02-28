using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coralCollected;
    public TextMeshProUGUI collect;

    // Start is called before the first frame update
    void Start()
    {
        coralCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        collect.text = coralCollected.ToString();
    }
}
