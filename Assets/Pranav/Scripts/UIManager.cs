using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject BoxPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoxSpawnOnClick(string typeToSpawn)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Set a distance from the camera to place the object

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        switch (typeToSpawn)
        {
            case "line":
                GameObject box1 = Instantiate(BoxPrefab, worldPosition, Quaternion.identity);
                box1.GetComponent<BoxScript>().InitializeBox("line");
                break;
            case "speed":
               
                GameObject box2 = Instantiate(BoxPrefab, worldPosition, Quaternion.identity);
                box2.GetComponent<BoxScript>().InitializeBox("speed");
                break;
            case "jump":
               
                GameObject box3 = Instantiate(BoxPrefab, worldPosition, Quaternion.identity);
                box3.GetComponent<BoxScript>().InitializeBox("jump");
                break;
            default:
                
                GameObject box4 = Instantiate(BoxPrefab, worldPosition, Quaternion.identity);
                box4.GetComponent<BoxScript>().InitializeBox("simple");
                break;
        }
    }

    public void simpleButtonClicked()
    {
        
    }
    public void speedButtonClicked()
    {
       
    }
    public void jumpButtonClicked()
    {
        
    }
    public void lineButtonClicked()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Set a distance from the camera to place the object

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

       
    }
}
