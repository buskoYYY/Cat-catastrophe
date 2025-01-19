using TMPro;
using UnityEngine;
using YaAssets;

public class UITextDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currencyText;
    [SerializeField] private TextMeshProUGUI _currencyTimeEndPanelText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _timeEndTimerText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _nextLevelPrice;
    [SerializeField] private TextMeshProUGUI _extraTime;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private Timer _timer;
    [SerializeField] private OpenLevels _openLevels;
    [SerializeField] private ExtraTimeController _extraTimeController;

    private void Update()
    {
        _scoreText.text = _scoreManager.GetScore().ToString();
        _currencyText.text = _currencySystem.GetCurrency().ToString();
        _timeText.text = Mathf.Round(_timer.GetTime()).ToString();
        _timeEndTimerText.text = Mathf.Round(_timer.GetTime()).ToString();
        _currencyTimeEndPanelText.text = Localization.GetText("Ó ÂÀÑ ÅÑÒÜ ") + _currencySystem.GetCurrency();
        _nextLevelPrice.text =  _openLevels.GetNextLevel();
        _extraTime.text = _extraTimeController.ExtraTimeDisplayInfo();
        _coinText.text = YG.SavesYG.GetInt("coins").ToString();
    }
}

