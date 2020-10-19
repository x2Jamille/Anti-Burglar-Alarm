using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alarm : MonoBehaviour
{
    private AudioSource _alarm;
    private bool _isBurglarInside;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.volume = 0.001f;
    }

    private void Update()
    {
            if (!_isBurglarInside && _alarm.volume <= 0.01f)
                _alarm.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BurglarMovement>())
        {
            _isBurglarInside = true;
            _alarm.Play();
            _alarm.DOFade(1, 10);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BurglarMovement>())
        {
            _isBurglarInside = false;
            _alarm.DOFade(0, 5);
        }
    }
}
