using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : MonoBehaviour
{
    [Header("Settings")]
    private int _currentStage;
    private string stageKey = "currentStage";
    public int CurrentStage { get { return _currentStage; } }

    private void Start()
    {
        _currentStage = LoadStageNumber();
    }
    
    public void SaveStageNumber(int level)
    {
        PlayerPrefs.SetInt(stageKey, level);
        PlayerPrefs.Save();
    }

    public int LoadStageNumber()
    {
        if (PlayerPrefs.HasKey(stageKey))
        {
            int currentLevel = PlayerPrefs.GetInt(stageKey);
            return currentLevel;
        }
        return 1; //поменять, сделать общую переменную
    }
}
