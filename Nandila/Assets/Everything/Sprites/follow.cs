using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject player;
    private Vector3 offset = new Vector3(0,2.6f,-10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= player.transform.position + offset;
    }
}
