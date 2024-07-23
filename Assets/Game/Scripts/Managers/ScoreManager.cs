using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Settings")]
    private int _score = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            _score = PlayerPrefs.GetInt("coins");
        }
        else
        {
            PlayerPrefs.SetInt("coins", 0);
        }
        _score = PlayerPrefs.GetInt("coins", 0);
    }

    public void ModifyScore(int value)
    {
        _score += value;
    }

    public int GetScore()
    {
        _score = PlayerPrefs.GetInt("coins");
        return _score;
    }
    
    public void SaveScore()
    {
       PlayerPrefs.SetInt("coins", _score);
    }
}
