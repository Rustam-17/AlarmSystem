using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private bool _isAlarm;
    [SerializeField] private AudioSource _alarmSignalAudioSource;

    private void Update()
    {
        if (_isAlarm && _alarmSignalAudioSource.isPlaying == false)
        {
            _alarmSignalAudioSource.Play();
        }

        if (_isAlarm == false && _alarmSignalAudioSource.isPlaying)
        {
            _alarmSignalAudioSource.Stop();
        }
    }
}
