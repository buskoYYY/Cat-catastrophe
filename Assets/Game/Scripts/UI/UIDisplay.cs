using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private TextMeshProUGUI _currencyTimeEndPanel;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private Timer _timer;

    private void Update()
    {
        _scoreText.text = _scoreManager.GetScore().ToString();
        _currencyText.text = _currencySystem.GetCurrency().ToString();
        _timeText.text = Mathf.Round(_timer.GetTime()).ToString();
        _currencyTimeEndPanel.text = "” ¬¿Ã ≈—“‹ " + _currencySystem.GetCurrency();
    }
}

