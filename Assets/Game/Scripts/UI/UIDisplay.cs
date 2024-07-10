using System;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private GameObject _pawImage;
    [SerializeField] private GameObject _score;
    [SerializeField] private TweenScale _tweenScale;

    private void Update()
    {
        _scoreText.text = _scoreManager.GetScore().ToString();
        _currencyText.text = _currencySystem.GetCurrency().ToString();

    }

    public void TweenEffect()
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

