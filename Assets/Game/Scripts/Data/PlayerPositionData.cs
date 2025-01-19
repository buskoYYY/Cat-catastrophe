using UnityEngine;

public class PlayerPositionData : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject _playerPosition;
    [Header("Settings")]
    private string positionKey = "player_position";

    public void SavePlayerGamePosition(Vector3 playerPosition)
    {
        YG.SavesYG.SetString(positionKey, JsonUtility.ToJson(playerPosition));
        PlayerPrefs.Save();
    }
    public Vector3 LoadPlayerPosition()
    {
        if (YG.SavesYG.HasKey(positionKey))
        {
            string jsonString = YG.SavesYG.GetString(positionKey);
            Vector3 loadedPosition = JsonUtility.FromJson<Vector3>(jsonString);
            return loadedPosition;
        }
        else
        {
            return _playerPosition.transform.position;
        }
    }
}