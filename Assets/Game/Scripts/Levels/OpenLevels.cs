using UnityEngine;
using UnityEngine.UI;

public class OpenLevels : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Level[] _levels;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private SaveLevelData _saveLevelData;
    [SerializeField] private StageData _stageData;
    [SerializeField] private WallStateData _wallStateData;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _timeendPanel;
    [SerializeField] private Image _pawImage;

    [Header("Settings")]
    private int _currentLevel;
    private int _currenceAmmount;
    private int _currentLevelPrice;
    private string _nextLevelPriceText;
    private bool _isLevelSelected; 

    private void Start()
    {
        _wallStateData.SetWallsState(_levels);
        _currentLevel = _stageData.CurrentStage;
    }

    public void LoadNextLevel()
    {
        _isLevelSelected = true;
        _currenceAmmount = _currencySystem.GetCurrency();
        for (int i = 0; i < _levels.Length; i++)
        {
            if (i == _currentLevel - 1)
            {
                _currenceAmmount = _currencySystem.GetCurrency();
                if (_currenceAmmount >= _levels[i].price)
                {
                    _timeendPanel.SetActive(false);
                    _currencySystem.SubtractCurrency(_levels[i].price);
                    _currentLevel++;
                    _levels[i].wall.SetActive(false);
                    _timer.ReloadTime();
                    Vector3 playerSpawnPosition = _levels[i].spawnPosition.position;
                    _saveLevelData.SaveData(playerSpawnPosition, _currentLevel);
                    return;
                }
                else
                {
                    _button.interactable = false;
                    _button.interactable = true;
                }
            }
        }
    }

    public string GetNextLevelPrice()
    {
        if (_currentLevel <= _levels.Length)
        {
            _currentLevelPrice = _levels[_currentLevel - 1].price;
            _nextLevelPriceText = "×ÒÎ ÁÛ ÎÒÊÐÛÒÜ ÑËÅÄÓÞÙÈÉ ÓÐÎÂÅÍÜ ÂÀÌ ÍÓÆÍÎ " + _currentLevelPrice;
        }
        else
        {
            _nextLevelPriceText = "ÏÎÇÄÐÀÂËßÅÌ, ÂÛ ÏÐÎØËÈ ÂÑÅ ÓÐÎÂÍÈ!!!";
            _pawImage.gameObject.SetActive(false);
        }
        return _nextLevelPriceText;
    }
}