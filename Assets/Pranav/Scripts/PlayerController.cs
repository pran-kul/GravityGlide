using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _CarRb;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private float speed ;
    [SerializeField] private float torque;
    private float CurrentTorque,currentSpeed;

    [SerializeField] private WheelJoint2D backWheel, frontWheel;
    private JointMotor2D backMotor, frontMotor;

    private float _moveInput;
    bool vehicleIsMoving = true;

    Coroutine drawing;
    public GameObject Line;
    public bool canDraw = false;


    public float stuckDuration = 5f; 
    private float timeSinceLastMovement = 0f;
    private Vector3 lastPosition;


    private void Start()
    {
        CurrentTorque = torque;
        currentSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (vehicleIsMoving) 
        {
            //_frontTireRB.AddTorque( -speed * Time.fixedDeltaTime);
            //_backTireRB.AddTorque(-speed * Time.fixedDeltaTime);

            frontMotor.motorSpeed = -currentSpeed;
            backMotor.motorSpeed = -currentSpeed;

            frontMotor.maxMotorTorque = CurrentTorque;
            backMotor.maxMotorTorque = CurrentTorque;

            frontWheel.motor = frontMotor;
            backWheel.motor = backMotor;

           // _CarRb.velocity = Vector3.ClampMagnitude(_CarRb.velocity, maxspeed);
            Camera.main.transform.position = new Vector3( transform.position.x + 10, transform.position.y +2, Camera.main.transform.position.z);
        }

        if (canDraw)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartLine();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                FinishLine();
            }
        }


        if (Vector3.Distance(transform.position, lastPosition) < 0.01f)
        {
            timeSinceLastMovement += Time.deltaTime;

            if (timeSinceLastMovement >= stuckDuration)
            {
                // Car is stuck, end the game
                EndGame();
            }
        }
        else
        {
            timeSinceLastMovement = 0f;
            lastPosition = transform.position;
        }

    }

    private void EndGame()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(0);
    }

    public void ChangeMaxSpeedFor(float newSpeed,float newMaxSpeed, int time)
    {
        StartCoroutine(ChangeMaxSpeed(newSpeed, newMaxSpeed, time));
    }

    public IEnumerator ChangeMaxSpeed(float newSpeed, float newMaxTorque, int time)
    {
        currentSpeed= newSpeed;
        CurrentTorque = newMaxTorque;

        yield return new WaitForSeconds(time);

        CurrentTorque = torque;
        currentSpeed = speed;
    }

    public void ChangeMaxSpeed(float newSpeed, float newMaxSpeed)
    {
        speed = newSpeed;
       
    }

    void StartLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }

    void FinishLine()
    {
        StopCoroutine(drawing);
        // Add a PolygonCollider2D component
        PolygonCollider2D collider = lineObject.AddComponent<PolygonCollider2D>();

        
        // Get points from the LineRenderer
        Vector2[] points = new Vector2[lineRendererAdded.positionCount];
        for (int i = 0; i < lineRendererAdded.positionCount; i++)
        {
            points[i] = lineRendererAdded.GetPosition(i);
        }
        // Set the points for the PolygonCollider2D
        collider.points = points;

        
        Material material = lineRendererAdded.material;

        // Ensure the material is set to a "Sprites/Default" shader
        // This is a common shader used for LineRenderer materials
        material.shader = Shader.Find("Sprites/Default");

        // Set the new color
        material.color = new Color32(38, 16, 0, 255);

        canDraw = false;


    }
    GameObject lineObject;
    LineRenderer lineRendererAdded;
    IEnumerator DrawLine()
    {
        lineObject = Instantiate(Line as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        lineRendererAdded = lineObject.GetComponent<LineRenderer>();
        lineRendererAdded.positionCount = 0;

        while (true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            lineRendererAdded.positionCount++;
            lineRendererAdded.SetPosition(lineRendererAdded.positionCount - 1, position);

           

          
            
            yield return null;
        }
    }






}
