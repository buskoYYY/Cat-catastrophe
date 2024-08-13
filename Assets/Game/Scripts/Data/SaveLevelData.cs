using UnityEngine;

[RequireComponent(typeof(StageData))]
public class SaveLevelData : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private PlayerPositionData _playerPosition;
    private StageData _levelData;

    private void Awake()
    {
        _levelData = GetComponent<StageData>();
    }
    public void SaveData(Vector3 currentLevelPosition, int currentLevel)
    {
        _playerPosition.SavePlayerGamePosition(currentLevelPosition);
        _levelData.SaveStageNumber(currentLevel);
    }
}
