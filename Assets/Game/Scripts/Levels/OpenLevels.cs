using UnityEngine;
using UnityEngine.UI;

public class OpenLevels : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Level [] _levels;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private SaveLevelData _saveLevelData;
    [SerializeField] private StageData _stageData;
    [SerializeField] private WallStateData _wallStateData;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _timeendPanel;

    [Header("Settings")]
    private int _currentLevel; 
    private int _currenceAmmount;

    private void Start()
    {
        _wallStateData.SetWallsState(_levels);

    }
    public void LoadNextLevel()
    {
        _currenceAmmount = _currencySystem.GetCurrency();
        _currentLevel = _stageData.CurrentStage;

        for (int i = 0; i < _levels.Length; i++)
        {
            if (i == _currentLevel - 1)
            {
                if (_currenceAmmount >= _levels[i].price)
                {
                    _timeendPanel.SetActive(false);
                    _currencySystem.SubtractCurrency(_levels[i].price);
                    _currentLevel++;
                    _levels[i].wall.SetActive(false);
                    _timer.ReloadTime();
                    Vector3 playerSpawnPosition = _levels[i].spawnPosition.position;
                    _saveLevelData.SaveData(playerSpawnPosition, _currentLevel);
                }
                else
                {
                    _button.interactable = false;
                    _button.interactable = true;
                }
            }
        }
    }

   
}