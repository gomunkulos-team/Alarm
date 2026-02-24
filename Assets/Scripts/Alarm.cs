using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmZone _zone;
    [SerializeField] private float _timeDelayForIncrese;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    private string _messageForStartAlarm = "Alarm On";
    private string _messageForStopAlarm = "Alarm Off";

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _zone.AlarmState += SwitchAlarmState;
    }

    private void OnDisable()
    {
        _zone.AlarmState -= SwitchAlarmState;
    }

    private void SwitchAlarmState(string alarmState)
    {
        if (alarmState == _messageForStartAlarm)
        {
            if (_audioSource.isPlaying == false)
                _audioSource.Play();

            ChangeAlarmSound(_maxVolume);
        }
        else if (alarmState == _messageForStopAlarm)
        {
            ChangeAlarmSound(_minVolume);
        }
    }

    private void ChangeAlarmSound(float targetVolume)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeAlarmVolume(targetVolume));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeAlarmVolume(targetVolume));
        }
    }

    private IEnumerator ChangeAlarmVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            yield return new WaitForEndOfFrame();
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _timeDelayForIncrese * Time.deltaTime);
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
