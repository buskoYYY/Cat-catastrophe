using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioState : MonoBehaviour
{
    [Header("Actions")]
    public static Action SoundOn;
    public static Action SoundOff;

    [Header("Elements")]
    [SerializeField] private TMP_Dropdown _dropdown;

    [Header("Settings")]
    private const string muted = nameof(muted);
    private bool _isMuted = false;

    private void Awake()
    {

        _dropdown = FindObjectOfType<TMP_Dropdown>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(muted))
        {
            PlayerPrefs.SetInt(muted, 0);
        }
        else
        {
            LoadAudioState();
        }
    }
    private void LoadAudioState()
    {
        _dropdown.value = PlayerPrefs.GetInt(muted);
    }

    private void SaveAudioState()
    {
        PlayerPrefs.SetInt(muted, _dropdown.value);
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

