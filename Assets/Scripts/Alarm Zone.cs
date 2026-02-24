using System;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    private string _message;

    public event Action<string> AlarmState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            _message = "Alarm On";
            AlarmState?.Invoke(_message);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            _message = "Alarm Off";
            AlarmState?.Invoke(_message);
        }
    }
}
