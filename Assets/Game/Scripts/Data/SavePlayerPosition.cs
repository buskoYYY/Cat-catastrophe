using UnityEngine;

public class SavePlayerPosition : MonoBehaviour
{
    [Header("Settings")]
    private string positionKey = "player_position";

    public void SavePlayerGamePosition(Vector3 position)
    {
        PlayerPrefs.SetString(positionKey, JsonUtility.ToJson(position));
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
            return Vector3.zero; // or any default position
        }
    }
}