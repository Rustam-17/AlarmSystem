using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrookMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _force;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _brackingForce;

    private Vector2 _leftDirection;
    private Vector2 _rightDirection;
    private float _currentSpeed;

    private void Start()
    {
        _leftDirection = new Vector2(-1, 0);
        _rightDirection = new Vector2(1, 0);
    }

    private void Update()
    {
        _currentSpeed = Mathf.Abs(_rigidbody2D.velocity.x);

        if (_currentSpeed < _maxSpeed)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _rigidbody2D.AddForce(_leftDirection * _force);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _rigidbody2D.AddForce(_rightDirection * _force);
            }
            else if (_currentSpeed > 0)
            {                
                Vector2 currenMotion = _rigidbody2D.velocity;
                currenMotion.Normalize();
                _rigidbody2D.AddForce( currenMotion * -_brackingForce);
            }
        }
    }
}
