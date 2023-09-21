using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float upDownSpeed = 2.0f; // Speed at which the object moves up and down.
    public float upDownDistance = 2.0f; // Distance the object moves up and down.

    private Vector3 initialPosition;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);
            if (transform.position.y >= initialPosition.y + upDownDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * upDownSpeed * Time.deltaTime);
            if (transform.position.y <= initialPosition.y)
            {
                movingUp = true;
            }
        }
    }
}
