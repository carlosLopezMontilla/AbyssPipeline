using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 highPosition;
    void Update()
    {
        transform.position = player.position + highPosition;
    }
}

