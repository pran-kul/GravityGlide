using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loss : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player"|| Input.GetKeyDown(KeyCode.R) )
        {
         
    SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
        
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) )
        {
         
    SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
        
        }
    }
}
