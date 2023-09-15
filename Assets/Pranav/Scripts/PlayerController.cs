using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float gravityValue = 1f;// The float value you want to manipulate
    public float windValue = 0f;
    public float windAngle;
    float angleInRadians;
    Vector2 windDirection;

    //public float gravityIncrement = 0.01f; // How much the value changes per key press, currently not being used
    //public float windIncrement = 0.01f;
    //public float gravityMinValue = -1.0f; // The minimum value
    //public float gravityMaxValue = 1.0f; // The maximum value
    //public float windMinValue = 0f; // The minimum value
    //public float windMaxValue = 1.0f; // The maximum value

    public float windSpeed = 10.0f;

    public List<Rigidbody2D> rigidBodyList = new List<Rigidbody2D>();
    public Scrollbar gravityScroll,windScroll;

    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _CarRb;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationspeed = 300f;
    private float _moveInput;

  

    void Update()
    {
        // Check if the player is pressing the up arrow key
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //if (gravityValue - gravityIncrement > 0)
            //{
            //    gravityValue = 0;
            //}
            //// Decrease the value, but clamp it within the specified range
            //gravityValue = Mathf.Clamp(gravityValue - gravityIncrement , gravityMinValue, gravityMaxValue);
            //physicsChanging = true;
            gravityValue = -1;
        }

        // Check if the player is pressing the down arrow key
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Increase the value, but clamp it within the specified range
            //if(gravityValue + gravityIncrement >0 )
            //{
            //    gravityValue = 1;
            //}
            //else
            //{
            //    gravityValue = Mathf.Clamp(gravityValue + gravityIncrement, gravityMinValue, gravityMaxValue);
            //}
            gravityValue = 1;


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Decrease the value, but clamp it within the specified range
            //windValue = Mathf.Clamp(windValue + windIncrement, windMinValue, windMaxValue);
            windValue = 1;

        }

        // Check if the player is pressing the down arrow key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Increase the value, but clamp it within the specified range
            //windValue = Mathf.Clamp(windValue - windIncrement, windMinValue, windMaxValue);
            windValue = 0;


        }

        
        UdateWorldPhysics();

        _moveInput = Input.GetAxisRaw("Horizontal");
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        //_CarRb.AddForce(_moveInput * _rotationspeed * Time.fixedDeltaTime);


    }

 
   
    public void UdateWorldPhysics()
    {
        gravityScroll.value = 1- ((gravityValue + 1) / 2);
        windScroll.value = windValue;

        foreach ( Rigidbody2D body in rigidBodyList)
        {
            body.gravityScale = gravityValue;

            

        }
        angleInRadians = windAngle * Mathf.Deg2Rad; // Convert degrees to radians
        windDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        // Apply the wind force in the calculated direction.
        _CarRb.AddForce(windDirection * windSpeed * windValue, ForceMode2D.Force);
        _CarRb.velocity = Vector3.ClampMagnitude(_CarRb.velocity, 10);
    }
}
