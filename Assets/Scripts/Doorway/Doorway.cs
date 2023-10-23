using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Doorway : MonoBehaviour
{
    [SerializeField] private UnityEvent _needOpenDoor;
    [SerializeField] private UnityEvent _needCloseDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out _))
        {
            _needOpenDoor?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out _))
        {
            _needCloseDoor?.Invoke();
        }
    }
}