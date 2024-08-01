using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioPlayer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] AudioClip hittingClip;
    [SerializeField][Range(0f, 1f)] float hittingVolume = 1f;
    private AudioSource _audioSource;

    [Header("Elements")]
    private bool _isUnmute = true;

    public static AudioPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        ToggleAudioState.SoundOff += MusicOff;
        ToggleAudioState.SoundOn += MusicOn;
    }
    private void OnDisable()
    {
        ToggleAudioState.SoundOff -= MusicOff;
        ToggleAudioState.SoundOn -= MusicOn;
    }
    public void PlayHittingClip()
    {
        if(_isUnmute)
        PlayClip(hittingClip, hittingVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
    private void MusicOn()
    {
        _audioSource.enabled = true;
        _isUnmute = true;
    }
    private void MusicOff()
    {
        _audioSource.enabled = false;
        _isUnmute = false;
    }
}
