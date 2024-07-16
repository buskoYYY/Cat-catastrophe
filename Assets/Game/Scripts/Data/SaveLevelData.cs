using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelData : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SavePlayerPosition _playerPosition;
    public void SaveData(Vector3 nextLevelPlayerPOsition)
    {
        _playerPosition.SavePlayerGamePosition(nextLevelPlayerPOsition);
    }
}
