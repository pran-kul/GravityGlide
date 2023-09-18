using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _frontTireRB;
     [SerializeField] private Rigidbody2D _CarRb;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private float _speed= 150f;
    [SerializeField] private float _rotationspeed= 300f;
    private float _moveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput= Input.GetAxisRaw("Horizontal");
        _frontTireRB.AddTorque(- _moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(- _moveInput * _speed * Time.fixedDeltaTime);
        _CarRb.AddTorque(_moveInput * _rotationspeed * Time.fixedDeltaTime);
        _CarRb.velocity = Vector3.ClampMagnitude(_CarRb.velocity, 10);
    }

}
