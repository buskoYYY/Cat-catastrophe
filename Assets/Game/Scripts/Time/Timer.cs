using System;
using UnityEngine;

[RequireComponent(typeof(ExtraTimeController))]
[RequireComponent(typeof(PauseTimer))]
public class Timer : MonoBehaviour
{
    [Header("Action")]
    public static Action AcivateTimeEndPanel;
    public static Action DeacivateTimeEndPanel;
    public static Action StartCountdownEffect;
    public static Action StopCountdownEffect;

    [Header("Elements")]
    [SerializeField] private GameObject _timeEndTimer;
    private ExtraTimeController _extraTimeController;
    private PauseTimer _pauseTimer;

    [Header("Settings")]
    [SerializeField] private float _playTime;
    [SerializeField] private int _countdownTime;
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

    public void ReloadTime()
    {
        _playTime = _initialPlayTime;
    }
    private void SetTimer()
    {
        _playTime -= Time.deltaTime;
        int remainingTime = (int)_playTime;

        if(remainingTime == _countdownTime-1)
        {
            StartCountdownEffect?.Invoke();
            _timeEndTimer.SetActive(true);
        }

        else if (remainingTime == 0)
        {
            _playTime = 0;
            _timeEndTimer.SetActive(false);
            AcivateTimeEndPanel?.Invoke();
            StopCountdownEffect?.Invoke();
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
