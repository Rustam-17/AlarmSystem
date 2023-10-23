using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject _hinge;
    [SerializeField] private GameObject _barrier;
    [SerializeField] private float _openingTime;
    [SerializeField] private bool _mustMoved;
    [SerializeField] private bool _isOpening;

    private Transform _hingeTransform;
    private Quaternion _closeRotation;
    private Quaternion _openedRotation;
    private Quaternion _currentRotation;
    private Quaternion _targetRotation;
    private float _semiOpenedRatio;
    private float _ratioStep;
    private float _ratio;

    private void Start()
    {
        _hingeTransform = _hinge.GetComponent<Transform>();

        _closeRotation = Quaternion.Euler(0, 90, 0);
        _openedRotation = Quaternion.Euler(0, -30, 0);
        _currentRotation = _hingeTransform.rotation;
        _semiOpenedRatio = 0.5f;

        _ratioStep = 1 / (_openingTime / Time.deltaTime);
        _ratio = 0;
    }

    private void Update()
    {
        if (_mustMoved)
        {
            MoveDoor();
        }
    }

    private void MoveDoor()
    {
        if (_isOpening)
        {
            _targetRotation = _openedRotation;
        }
        else
        {
            _targetRotation = _closeRotation;
        }

        _hingeTransform.rotation = Quaternion.Slerp(_currentRotation, _targetRotation, _ratio);
        _ratio += _ratioStep;

        if (_ratio > _semiOpenedRatio)
        {
            _barrier.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (_hingeTransform.rotation == _targetRotation)
        {
            _mustMoved = false;
            _ratio = 0;
        }
    }

    public void InitiateMoving()
    {
        _mustMoved = true;
        _isOpening = !_isOpening;

        _currentRotation = _hingeTransform.rotation;
        _ratio = 0;
    }
}