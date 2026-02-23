using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _targetVolume = 0;
    private float _timeDelayForIncrese = 0.2f;

    private void Start()
    {
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _timeDelayForIncrese * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();

        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            _targetVolume = _maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            _targetVolume = _minVolume;
        }
    }
}
