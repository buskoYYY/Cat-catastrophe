using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelData : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private PlayerPositionData _playerPosition;
    [SerializeField] private StageData _levelData;
    public void SaveData(Vector3 currentLevelPosition, int currentLevel)
    {
        _playerPosition.SavePlayerGamePosition(currentLevelPosition);
        _levelData.SaveStageNumber(currentLevel);
    }
}
