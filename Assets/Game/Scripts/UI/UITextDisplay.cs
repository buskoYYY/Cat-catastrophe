using TMPro;
using UnityEngine;

public class UITextDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private TextMeshProUGUI _currencyTimeEndPanelText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private Timer _timer;

    private void Update()
    {
        _scoreText.text = _scoreManager.GetScore().ToString();
        _currencyText.text = _currencySystem.GetCurrency().ToString();
        _timeText.text = Mathf.Round(_timer.GetTime()).ToString();
        _currencyTimeEndPanelText.text = "” ¬¿Ã ≈—“‹ " + _currencySystem.GetCurrency();
        _coinText.text = PlayerPrefs.GetInt("coins").ToString();
    }
}

