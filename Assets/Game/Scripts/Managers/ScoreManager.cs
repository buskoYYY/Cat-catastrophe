using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Settings")]
    private int _score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);

        _score = PlayerPrefs.GetInt("coins", 0);

    }

    public void ModifyScore(int value)
    {
        _score += value;
    }

    public int GetScore()
    {
        return _score;
    }
    
    public void SaveScore()
    {
       PlayerPrefs.SetInt("coins", _score);
    }
}
