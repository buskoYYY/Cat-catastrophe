using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YaAssets;

public class OpenLevels : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Level[] _levels;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private SaveLevelData _saveLevelData;
    [SerializeField] private StageData _stageData;
    [SerializeField] private WallStateData _wallStateData;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _openLevelButton;
    [SerializeField] private Button startNewGameButton;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _timeendPanel;
    [SerializeField] private AIActivator _aIActivtor;
    [SerializeField] private Image _pawImage;

    [Header("Settings")]
    private int _currentLevel;
    private int _currenceAmmount;
    private int _currentLevelPrice;
    private int _firtSceneIndex = 1;
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
                    LoadLevelRoutine(i);
                    return;
                }
                else
                {
                    _openLevelButton.interactable = false;
                    _openLevelButton.interactable = true;
                }
            }
            _aIActivtor.StartAI(i);
        }
    }

    private void LoadLevelRoutine(int i)
    {
        _timeendPanel.SetActive(false);
        _currencySystem.SubtractCurrency(_levels[i].price);
        _currentLevel++;
        _levels[i].wall.SetActive(false);
        _timer.ReloadTime();
        Vector3 playerSpawnPosition = _levels[i].spawnPosition.position;
        _saveLevelData.SaveData(playerSpawnPosition, _currentLevel);
    }

    public string GetNextLevel()
    {
        if (_currentLevel <= _levels.Length)
        {
            _currentLevelPrice = _levels[_currentLevel - 1].price;
            _nextLevelPriceText = Localization.GetText("×ÒÎ ÁÛ ÎÒÊÐÛÒÜ ÑËÅÄÓÞÙÈÉ ÓÐÎÂÅÍÜ ÂÀÌ ÍÓÆÍÎ ") + _currentLevelPrice;
        }
        else
        {
            _nextLevelPriceText = Localization.GetText("ÏÎÇÄÐÀÂËßÅÌ, ÂÛ ÏÐÎØËÈ ÂÑÅ ÓÐÎÂÍÈ!!!");
            _pawImage.gameObject.SetActive(false);
            _openLevelButton.gameObject.SetActive(false);
            startNewGameButton.gameObject.SetActive(true);
        }
        return _nextLevelPriceText;
    }

    public void StartNewGame()
    {
        YG.SavesYG.DeleteAll();
        SceneManager.LoadScene(_firtSceneIndex);
    }
}