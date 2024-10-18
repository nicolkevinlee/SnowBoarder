using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D _rigidbody;
    SurfaceEffector2D _surfaceEffector;
    [SerializeField] float _torqueAmount = 2f;
    [SerializeField] float _baseSpeed = 20f;
    [SerializeField] float _boostSpeed = 30f;
    bool _moveable = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveable)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody.AddTorque(_torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody.AddTorque(-_torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector.speed = _boostSpeed;
        }
        else{
            _surfaceEffector.speed = _baseSpeed;
        }
    }

    public void DisableControls(){
        _moveable = false;
    }
}
