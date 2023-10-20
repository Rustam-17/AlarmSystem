using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _openTime;
    [SerializeField] private bool _mustOpened;
    [SerializeField] private bool _mustClosed;

    private Quaternion _closeRotation;
    private Quaternion _openedRotation;
    private float _openRatioStep;
    private float _openRatio;
    private bool _isOpened;

    private void OnValidate()
    {
        _mustOpened = !_mustClosed;
    }

    private void Start()
    {
        _closeRotation = Quaternion.Euler(0, 90, 0);
        _openedRotation = Quaternion.Euler(0, -30, 0);

        _openRatioStep = 1 / (_openTime / Time.deltaTime);
        _openRatio = 0;

        Debug.Log(_openRatioStep);
    }

    private void Update()
    {
        if (_mustOpened && _isOpened == false)
        {
            transform.rotation = Quaternion.Slerp(_closeRotation, _openedRotation, _openRatio);
            _openRatio += _openRatioStep;

            if (transform.rotation == _openedRotation)
            {
                _isOpened = true;
            }

            Debug.Log(_openRatioStep);
        }
    }

    public void InitiateOpen()
    {
        _mustOpened = true;
    }

    public void InitiateClose()
    {
        _mustOpened = true;
    }
}