using System;
using UnityEngine;

public class TweenEffects : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TweenScale _tweenScale;
    [SerializeField] private TweenScale _tweenScaleForTimeRemineder;
    [SerializeField] private GameObject _pawImage;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _endTime;

    private void OnEnable()
    {
        //Timer.StartCountdownEffect += TweenEndTimeRiminderEffect;
    }
    public void TweenScaleEffect()
    {
        iTween.PunchScale(_pawImage, _tweenScale.scale, _tweenScale.scaleTime);
        iTween.PunchScale(_score, _tweenScale.scale, _tweenScale.scaleTime);
    }

    public void TweenEndTimeRiminderEffect()
    {
        iTween.PunchScale(_endTime, _tweenScaleForTimeRemineder.scale, _tweenScaleForTimeRemineder.scaleTime);
    }

    private void OnDisable()
    {
        //Timer.StartCountdownEffect -= TweenEndTimeRiminderEffect;
    }

    [Serializable]
    class TweenScale
    {
        public Vector3 scale;
        public float scaleTime;
    }
}
