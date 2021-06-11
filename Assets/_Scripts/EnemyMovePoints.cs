using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePoints : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    public Transform parent;
    public float currentRotation;
    int NextPosIndex;
    Transform nextPoint;


    // Start is called before the first frame update
    void Start()
    {
        nextPoint = Positions[0];
        currentRotation = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject()
    {
        if (transform.position == nextPoint.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            if (NextPosIndex == 0)
            {
                transform.LookAt(Positions[0]);
            }
             if (NextPosIndex == 1)
            {
                transform.LookAt(Positions[1]);
            }

            nextPoint = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, ObjectSpeed * Time.deltaTime);
        }
    }
}
