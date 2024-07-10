using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _playTime;
    private bool _isGameEnded = false;

    public bool IsGameEnded { get { return _isGameEnded; } }


    private void Update()
    {
        SetTimer();
    }
    private void SetTimer()
    {
        _playTime -= Time.deltaTime;
        int remaining = (int) _playTime;

        if (remaining == 0)
        {
            _isGameEnded = true;
            _playTime = 0;
        }
    }

    public float GetTime()
    {
        return  _playTime;
    }
}
