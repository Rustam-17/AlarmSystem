using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _someoneCameIn;
    [SerializeField] private UnityEvent _enteredCameOut;
    [SerializeField] private AudioSource _audioSourceWorkingIndicator;
    [SerializeField] private bool _isWorking;

    private Collider2D _enteredCollider;

    private void Update()
    {
        if (_isWorking && _audioSourceWorkingIndicator.isPlaying == false)
        {
            _audioSourceWorkingIndicator.Play();
        }

        if (_isWorking == false && _audioSourceWorkingIndicator.isPlaying)
        {
            _audioSourceWorkingIndicator.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isWorking)
        {
            _enteredCollider = collision;
            _someoneCameIn?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isWorking)
        {
            if (collision == _enteredCollider)
            {
                _enteredCameOut?.Invoke();
            }
        }
    }
}
