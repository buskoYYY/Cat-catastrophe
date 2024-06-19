using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Hitting")]
    [SerializeField] AudioClip hittingClip;
    [SerializeField][Range(0f, 1f)] float hittingVolume = 1f;

    public static AudioPlayer instance;

    [Header("Settings")]
    private int _score;

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

    public void PlayHittingClip()
    {
        PlayClip(hittingClip, hittingVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
