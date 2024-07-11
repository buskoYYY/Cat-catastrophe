using NaughtyAttributes;
using NaughtyAttributes.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExtraTimeController))]
[RequireComponent(typeof(PauseTimer))]
public class Timer : MonoBehaviour
{
    public static Action AcivateTimeEndPanel;
    public static Action DeacivateTimeEndPanel;

    [Header("Elements")]
    private ExtraTimeController _extraTimeController;
    private PauseTimer _pauseTimer;

    [Header("Settings")]
    [SerializeField] private float _playTime;
    private float _initialPlayTime;


    private void Start()
    {
        _extraTimeController = GetComponent<ExtraTimeController>();
        _pauseTimer = GetComponent<PauseTimer>();
        _initialPlayTime = _playTime;
    }

    private void OnEnable()
    {
        ExtraTimeController.AddExtraTime += AddTime;
    }

    private void Update()
    {
        if (_pauseTimer.IsTimerPaused == false)
        {
            SetTimer();
        }
    }
    private void SetTimer()
    {
        _playTime -= Time.deltaTime;
        int remainingTime = (int)_playTime;

        if (remainingTime == 0)
        {
            _playTime = 0;
            AcivateTimeEndPanel?.Invoke();
        }
        else
        {
            DeacivateTimeEndPanel?.Invoke();
        }
    }
    public float GetTime()
    {
        return _playTime;
    }

    private void AddTime()
    {
        _playTime += _extraTimeController.ExtraTime;
    }
    private void OnDisable()
    {
        ExtraTimeController.AddExtraTime -= AddTime;
    }

}
