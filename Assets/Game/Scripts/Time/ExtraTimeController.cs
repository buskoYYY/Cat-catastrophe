using NaughtyAttributes;
using System;
using UnityEngine;

public class ExtraTimeController : MonoBehaviour
{
    public static Action AddExtraTime;

    [Header("Settings")]
    [SerializeField] private float _extraTime;
    public float ExtraTime {  get { return _extraTime; }}
    [SerializeField] private int _extraTimeAmmount;
    private int _initialExtraTimeAmmount;
    private bool _isExtraTimeAvailable => _extraTimeAmmount > 0;

    private void Start()
    {
        _initialExtraTimeAmmount = _extraTimeAmmount;
    }

    [Button("AddExtraTimeAmmount")]
    private void WatchAdds()
    {
        Debug.Log("You watched adds and get extraTime");
        _extraTimeAmmount = _initialExtraTimeAmmount;
    }

    public void GetExtraTime()
    {
        if (_isExtraTimeAvailable)
        {
            _extraTimeAmmount--;
            AddExtraTime?.Invoke();
        }
        else
        {
            Debug.Log("Extra time is not available");
        }
    }
}
