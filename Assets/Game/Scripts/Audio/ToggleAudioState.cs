using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioState : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image _soundOnIcon;
    [SerializeField] private Image _soundOffIcon;

    [Header("Settings")]
    private const string muted = nameof(muted);
    private bool _isMuted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(muted))
        {
            PlayerPrefs.SetInt(muted, 0);
            LoadAudioState();
        }
        else
        {
            LoadAudioState();
        }
        UpdateButtonIcon();
        AudioListener.pause = _isMuted;
    }

    public void OnButtonPresss()
    {
        if (_isMuted == false)
        {
            _isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            _isMuted = false;
            AudioListener.pause = false;
        }
        SaveAudioState();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (_isMuted == false)
        {
            _soundOnIcon.enabled = true;
            _soundOffIcon.enabled = false;
        }
        else
        {
            _soundOnIcon.enabled = false;
            _soundOffIcon.enabled = true;
        }
    }

    private void LoadAudioState()
    {
        _isMuted = PlayerPrefs.GetInt(muted) == 1;
    }

    private void SaveAudioState()
    {
        PlayerPrefs.SetInt(muted, _isMuted ? 1 : 0);
    }
}
