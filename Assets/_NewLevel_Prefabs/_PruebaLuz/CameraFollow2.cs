using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public bool zoomActive;
    public Vector3[] Target;
    public Transform player;
    public float speed;
    public Transform cam;
    public Vector3 camMove;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zoomActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zoomActive = false;
        }
    }
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (zoomActive)
        {
            //cam.transform.position = player.transform.position + Vector3.Lerp(Target[1], Target[0], speed * Time.deltaTime);
            camMove = Vector3.MoveTowards(Target[1], Target[0], step);
        }
        else
        {
            //cam.transform.position = player.transform.position + Vector3.Lerp(Target[0], Target[1], speed * Time.deltaTime);
            camMove = Vector3.MoveTowards(Target[0], Target[1], step);

        }

        cam.transform.position = player.transform.position + camMove;
    }
}
