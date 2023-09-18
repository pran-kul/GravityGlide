using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _CarRb;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private float speed = 150f;
    [SerializeField] private float maxspeed = 4;
    [SerializeField] private float _rotationspeed = 300f;
    private float _moveInput;
    bool vehicleIsMoving = true;

    Coroutine drawing;
    public GameObject Line;
    public bool CanDraw = false;

    // Update is called once per frame
    void Update()
    {
        if (vehicleIsMoving) 
        { 
            _moveInput = 0.5f;
            _frontTireRB.AddTorque(-_moveInput * speed * Time.fixedDeltaTime);
            _backTireRB.AddTorque(-_moveInput * speed * Time.fixedDeltaTime);
            //_CarRb.AddForce(_moveInput * _rotationspeed * Time.fixedDeltaTime);
            _CarRb.velocity = Vector3.ClampMagnitude(_CarRb.velocity, maxspeed);
        }

        if (CanDraw)
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

    }

    public void ChangeMaxSpeedTo(float newSpeed,float newMaxSpeed, int time)
    {
        StartCoroutine(ChangeMaxSpeed(newSpeed, newMaxSpeed, time));
    }

    public IEnumerator ChangeMaxSpeed(float newSpeed, float newMaxSpeed, int time)
    {
        speed = newSpeed;
        maxspeed = newMaxSpeed;

        yield return new WaitForSeconds(time);

        maxspeed = 4;
        speed = 150;
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

        // Get points from the LineRenderer
        Vector2[] points = new Vector2[lineRendererAdded.positionCount];
        for (int i = 0; i < lineRendererAdded.positionCount; i++)
        {
            points[i] = lineRendererAdded.GetPosition(i);
        }

        // Add a PolygonCollider2D component
        PolygonCollider2D collider = lineObject.AddComponent<PolygonCollider2D>();

        // Set the points for the PolygonCollider2D
        collider.points = points;
        CanDraw = false;
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
