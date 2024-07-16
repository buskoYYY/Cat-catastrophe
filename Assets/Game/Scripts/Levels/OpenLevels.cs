using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class OpenLevels : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Level [] _levels;
    [SerializeField] private CurrencySystem _currencySystem;
    [SerializeField] private SaveLevelData _saveLevelData;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _timeendPanel;

    [Header("Settings")]
    public int _currentLevel = 1; // поменять на private
    private int _currenceAmmount;

    public void LoadNextLevel()
    {
        _currenceAmmount = _currencySystem.GetCurrency();

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
                    Vector3 playerSpawnPosition = _levels[i].spawnPosition.position;
                    _saveLevelData.SaveData(playerSpawnPosition);
                }
            }
        }
    }

   
}