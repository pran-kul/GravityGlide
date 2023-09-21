using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public string BoxType = "simple";
    bool isMovable = false;
    Vector3 newPosition;
    bool initialDrop = false;
    private void Start()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        OnMouseDown();
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && !initialDrop)
        {
            isMovable = false;
            initialDrop = true;
        }
        if(isMovable)
        {
            
            newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            // Keep the object's Z position unchanged
            newPosition.z = gameObject.transform.position.z;

            // Update the object's position
            gameObject.transform.position = newPosition;
        }
    }
    public void InitializeBox(string boxType)
    {
        BoxType = boxType;
        switch (BoxType)
        {
            case "simple":
                transform.GetComponent<Rigidbody2D>().mass= 20;

                break;
            case "line":
                transform.GetComponent<SpriteRenderer>().color = new Color32(89, 89, 89, 255);

                break;
            case "speed":
                transform.GetComponent<SpriteRenderer>().color = new Color32(130, 22, 0, 255);
                
                //some code 
                break;
            case "jump":
                transform.GetComponent<SpriteRenderer>().color = new Color32(96, 6, 192, 255);
                break;
            default:
                //some code 
                break;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( !isMovable)
        {
            switch (BoxType)
            {
                case "line":
                    if (collision.gameObject.GetComponent<PlayerController>())
                    {
                        collision.gameObject.GetComponent<PlayerController>().canDraw = true;
                        Destroy(gameObject);
                    }

                    break;
                case "speed":
                    if (collision.gameObject.GetComponent<PlayerController>())
                    {
                        collision.gameObject.GetComponent<PlayerController>().ChangeMaxSpeedFor(1400, 3000, 4);
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.gameObject.transform.right * 5000);
                        Destroy(gameObject);
                    }
                    //some code 
                    break;
                case "jump":
                    if (collision.gameObject.GetComponent<PlayerController>())
                    {
                        //collision.gameObject.GetComponent<PlayerController>().ChangeMaxSpeed(150, 4);
                        //upward force
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100f, ForceMode2D.Impulse);

                        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.gameObject.transform.right * 10000);
                        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 30000);
                        


                        Destroy(gameObject);
                    }
                    break;
                default:
                    //some code 
                    break;
            }
        }
        
    }

    private Vector3 offset;

    void OnMouseDown()
    {
        
        // Calculate the offset between the object's position and the mouse position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isMovable = true;
    }

    void OnMouseDrag()
    {
       
    }
    private void OnMouseUp()
    {
        isMovable = false;
    }
    private void OnMouseUpAsButton()
    {
        isMovable = false;
    }


}
