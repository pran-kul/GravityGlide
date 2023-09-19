using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public bool check = false;

    void LateUpdate()
    {
        if (Input.GetMouseButton(0) && check)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z
            transform.position = mouseWorldPos;
        }

    }

    void OnMouseDown()
    {
        check = true;
    }

        void OnMouseUp()
    {
        check = false;
    }
}
