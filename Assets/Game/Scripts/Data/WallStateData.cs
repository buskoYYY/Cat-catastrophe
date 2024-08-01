using UnityEngine;

[RequireComponent(typeof(StageData))]
public class WallStateData : MonoBehaviour
{
    [Header("Elements")]
    private StageData _stageData;

    [Header("Settings")]
    private int _currentlevelCount;

    private void Awake()
    {
        _stageData = GetComponent<StageData>();
    }
    private void Start()
    {
        _currentlevelCount = _stageData.LoadStageNumber();
    }

    public void SetWallsState(Level[] levels)
    {
        for (int i = 0; i < _currentlevelCount - 1; i++)
        {
            levels[i].wall.SetActive(false);
        }
    }
}
