using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _someoneCameIn;
    [SerializeField] private UnityEvent _enteredCameOut;
    //[SerializeField] private AudioSource _audioSourceWorkingIndicator;
    [SerializeField] private AudioSource _audioSourceAlarmSignal;
    [SerializeField] private bool _isWorking;

    private Collider2D _enteredCollider;

    private void Update()
    {
        //if (_isWorking && _audioSourceAlarmSignal.isPlaying == false)
        //{
        //    _audioSourceAlarmSignal.Play();
        //}

        //if (_isWorking == false && _audioSourceAlarmSignal.isPlaying)
        //{
        //    _audioSourceAlarmSignal.Stop();
        //}
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

    public void StopAlarmSignal()
    {
        Debug.Log("soundOff");
        _audioSourceAlarmSignal.Stop();
    }
}
