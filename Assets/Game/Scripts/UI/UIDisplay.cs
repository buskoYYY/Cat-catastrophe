using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private Timer _timer;
    [SerializeField] private ThirdPersonController _thirdPersonController;
    [SerializeField] private GameObject _pawImage;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _timeEndPanel;
    [SerializeField] private TweenScale _tweenScale;

    [Header("Setiings")]
    [SerializeField] private float _timeToLoadPanel;

    private void Update()
    {
        _scoreText.text = _scoreManager.GetScore().ToString();
        _currencyText.text = _currencySystem.GetCurrency().ToString();
        _timeText.text = Mathf.Round( _timer.GetTime()).ToString();
        OpenTimeEndPanel();

    }

    public void TweenEffect()
    {
        iTween.PunchScale(_pawImage, _tweenScale.scale, _tweenScale.scaleTime);
        iTween.PunchScale(_score, _tweenScale.scale, _tweenScale.scaleTime);
    }

    private void OpenTimeEndPanel()
    {
        if(_timer.IsGameEnded == true)
        {
            StartCoroutine(LoadTimeEndScene());
            _thirdPersonController.MoveDisable();
        }
    }

    IEnumerator LoadTimeEndScene()
    {
        yield return new WaitForSeconds(_timeToLoadPanel);
        _timeEndPanel.SetActive(true);
    }


    [Serializable]
    class TweenScale
    {
        public Vector3 scale;
        public float scaleTime;
    }
}

