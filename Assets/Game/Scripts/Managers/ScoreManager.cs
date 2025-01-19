using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Settings")]
    private int _score = 0;

    private void Awake()
    {
        if (YG.SavesYG.HasKey("coins"))
        {
            _score = YG.SavesYG.GetInt("coins");
        }
        else
        {
            YG.SavesYG.SetInt("coins", 0);
        }
        _score = YG.SavesYG.GetInt("coins", 0);
    }

    public void ModifyScore(int value)
    {
        _score += value;
    }

    public int GetScore()
    {
        _score = YG.SavesYG.GetInt("coins");
        return _score;
    }
    
    public void SaveScore()
    {
       YG.SavesYG.SetInt("coins", _score);
    }
}
