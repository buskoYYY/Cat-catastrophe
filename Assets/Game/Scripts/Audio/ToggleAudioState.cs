using System;
using TMPro;
using UnityEngine;

public class ToggleAudioState : MonoBehaviour
{
    [Header("Actions")]
    public static Action SoundOn;
    public static Action SoundOff;

    [Header("Elements")]
    [SerializeField] private TMP_Dropdown _dropdown;

    [Header("Settings")]
    private const string muted = nameof(muted);

    private void Awake()
    {
        _dropdown = FindObjectOfType<TMP_Dropdown>();
    }

    private void Start()
    {
        if (!YG.SavesYG.HasKey(muted))
        {
            YG.SavesYG.SetInt(muted, 0);
        }
        else
        {
            LoadAudioState();
        }
    }
    private void LoadAudioState()
    {
        _dropdown.value = YG.SavesYG.GetInt(muted);
    }

    private void SaveAudioState()
    {
        YG.SavesYG.SetInt(muted, _dropdown.value);
    }

    public void ToggleState()
    {
        if (_dropdown.value == 0)
        {
            SoundOn?.Invoke();
            SaveAudioState();
        }
        else if (_dropdown.value == 1)
        {
            SoundOff?.Invoke();
            SaveAudioState();
        }
    }
}

