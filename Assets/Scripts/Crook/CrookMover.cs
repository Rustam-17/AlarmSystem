using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrookMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _leftDirection;
    private Vector2 _rightDirection;

    private void Start()
    {
        _leftDirection = new Vector2(-1, 0);
        _rightDirection = new Vector2(1, 0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(_speed * Time.deltaTime * _leftDirection);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_speed * Time.deltaTime * _rightDirection);
        }
    }
}
