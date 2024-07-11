using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenEffects : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TweenScale _tweenScale;
    [SerializeField] private GameObject _pawImage;
    [SerializeField] private GameObject _score;
    public void TweenScaleEffect()
    {
        iTween.PunchScale(_pawImage, _tweenScale.scale, _tweenScale.scaleTime);
        iTween.PunchScale(_score, _tweenScale.scale, _tweenScale.scaleTime);
    }

    [Serializable]
    class TweenScale
    {
        public Vector3 scale;
        public float scaleTime;
    }
}
