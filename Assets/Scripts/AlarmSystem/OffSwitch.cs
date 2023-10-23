using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : StateMachineBehaviour
{
    [SerializeField] private Animation _alarmEndAnimation;
    [SerializeField] private AudioSource _audioSource;
        
    public void OnStateExit()
    {
        _audioSource.Stop();
    }
}
