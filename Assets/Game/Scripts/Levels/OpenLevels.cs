using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class OpenLevels : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Level [] _levels;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private SaveLevelData _saveLevelData;
    [SerializeField] private StageData _stageData;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _timeendPanel;

    [Header("Settings")]
    public int _currentLevel; // поменять на private
    private int _currenceAmmount;
    private int _currentlevelCount;

    private void Start()
    {
        _currentlevelCount = _stageData.LoadStageNumber();
        SetWallsState();
    }

    private void SetWallsState()
    {
        for(int i = 0; i < _currentlevelCount; i++ )
        {
            _levels[i].wall.SetActive(false);
        }
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
                    Debug.Log(_currentLevel);
                    _levels[i].wall.SetActive(false);
                    _timer.ReloadTime();
                    Vector3 playerSpawnPosition = _levels[i].spawnPosition.position;
                    _saveLevelData.SaveData(playerSpawnPosition, _currentLevel);
                }
                else
                {
                    Debug.Log("First level " + _currentLevel);
                    _button.interactable = false;
                    _button.interactable = true;
                }
            }
        }
    }

   
}