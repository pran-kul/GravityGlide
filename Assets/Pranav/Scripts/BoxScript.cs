using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public string BoxType = "simple";
    float ForceAngle = 60;
    float angleInRadians;
    Vector2 ForceDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (BoxType)
        {
            case "line":
                if (collision.gameObject.GetComponent<PlayerController>())
                {
                    collision.gameObject.GetComponent<PlayerController>().CanDraw = true;
                    Destroy(gameObject);
                }
                
                break;
            case "speed":
                if (collision.gameObject.GetComponent<PlayerController>())
                {
                    collision.gameObject.GetComponent<PlayerController>().ChangeMaxSpeedTo(350,20,4);
                    Destroy(gameObject);
                }
                //some code 
                break;
            case "jump":
                if (collision.gameObject.GetComponent<PlayerController>())
                {
                    //upward force
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6000);
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 6000);

                   
                    Destroy(gameObject);
                }
                break;
            default:
                //some code 
                break;
        }
    }

    private Vector3 offset;

    void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        // Calculate the new position based on the mouse position and offset
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

        // Keep the object's Z position unchanged
        newPosition.z = gameObject.transform.position.z;

        // Update the object's position
        gameObject.transform.position = newPosition;
    }
}
