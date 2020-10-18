using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alarm : MonoBehaviour
{

    private AudioSource _alarm;
    private bool _isBurglarInside;

    [SerializeField] private float _initialVolume;
    [SerializeField] private float _volumeUpStep;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.volume = _initialVolume;
    }

    private void Update()
    {
        if (_isBurglarInside)
        {
            _alarm.volume += _volumeUpStep * Time.deltaTime;
        }
        else
        {
            if (_alarm.volume <= _initialVolume)
                _alarm.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BurglarMovement>())
        {
            _isBurglarInside = true;
            _alarm.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BurglarMovement>())
        {
            _isBurglarInside = false;
            _alarm.DOFade(_initialVolume, 3);
        }
    }
}
