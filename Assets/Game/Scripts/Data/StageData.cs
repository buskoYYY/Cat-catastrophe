using UnityEngine;

public class StageData : MonoBehaviour
{
    [Header("Settings")]
    private int _startStage = 1;
    private int _currentStage;
    private string stageKey = "currentStage";
    public int CurrentStage { get { return _currentStage; } }

    private void Start()
    {
        _currentStage = LoadStageNumber();
    }
    
    public void SaveStageNumber(int level)
    {
        YG.SavesYG.SetInt(stageKey, level);
        PlayerPrefs.Save();
    }

    public int LoadStageNumber()
    {
        if (YG.SavesYG.HasKey(stageKey))
        {
            int currentLevel = YG.SavesYG.GetInt(stageKey);
            return currentLevel;
        }
        return _startStage; 
    }
}
