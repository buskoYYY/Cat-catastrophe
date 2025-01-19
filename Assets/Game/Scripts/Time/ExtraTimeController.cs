using System;
using UnityEngine;
using YaAssets;

public class ExtraTimeController : MonoBehaviour
{
    public static Action AddExtraTime;

    [Header("Settings")]
    [SerializeField] private float _extraTime; 
    public float ExtraTime { get { return _extraTime; } }
    private string _extraTimeInfo;


    public void WatchAdds()
    {
        AddExtraTime?.Invoke();
    }

    public string ExtraTimeDisplayInfo()
    {
        return _extraTimeInfo = Localization.GetText("ѕосмотреть рекламу и получить ") + _extraTime + Localization.GetText("с времени");
    }
}
