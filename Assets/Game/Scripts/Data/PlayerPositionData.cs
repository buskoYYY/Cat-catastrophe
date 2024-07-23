using UnityEngine;

public class PlayerPositionData : MonoBehaviour
{
    [Header("Settings")]
    private string positionKey = "player_position";

    public void SavePlayerGamePosition(Vector3 playerPosition)
    {
        PlayerPrefs.SetString(positionKey, JsonUtility.ToJson(playerPosition));
        PlayerPrefs.Save();
    }

    public Vector3 LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey(positionKey))
        {

            string jsonString = PlayerPrefs.GetString(positionKey);
            Vector3 loadedPosition = JsonUtility.FromJson<Vector3>(jsonString);
            Debug.Log("Player position loaded: " + loadedPosition);

            return loadedPosition;
        }
        else
        {
            
            Debug.Log("No saved player position found");
            return Vector3.zero;
        }
    }

}