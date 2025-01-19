using UnityEngine;

public class AIActivator : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject _oneAIEnemies; 
    [SerializeField] private GameObject[] _twoAIEnemies;

    [Header("Settings")]
    [SerializeField] private int _levelOpenOneAI;
    [SerializeField] private int _LevelOpenTwoAI;
    bool _isAIActive; 
    bool _isTwoAIActive;

    private void Start()
    {
        _isAIActive = GetAIState(); 
        _oneAIEnemies.SetActive(_isAIActive);

        _isTwoAIActive = GetTwoAIState();
        foreach(GameObject enemy in _twoAIEnemies)
        {
            enemy.SetActive(_isTwoAIActive);
        }
    }

    public void StartAI(int gameLevel)
    {
        StartAIPlayer(gameLevel);
        StartTwOAIPlayer(gameLevel);
    }
    public void StartAIPlayer(int level)
    {
        if (level == _levelOpenOneAI)
        {
            _oneAIEnemies.SetActive(true);
            _isAIActive = true;
            SetAIState(_isAIActive);

        }
    }
    public void StartTwOAIPlayer(int level)
    {
        if (level == _LevelOpenTwoAI)
        {
            foreach (GameObject enemyAI in _twoAIEnemies)
            {
                enemyAI.SetActive(true);
            }
            _isTwoAIActive = true;
            SetTwoAIState(_isTwoAIActive);
        }
    }

    public void AIActive() 
    {
        if (_oneAIEnemies.activeInHierarchy == false && GetAIState() == true)
        {
            _oneAIEnemies.SetActive(true);
        }
        foreach (GameObject enemy in _twoAIEnemies)
        {
            if (enemy.activeInHierarchy == false && GetTwoAIState() == true)
                enemy.SetActive(true);
        }
    }

    public void AIDisactive()
    {
        if(_oneAIEnemies.activeInHierarchy == true)
        {
            _oneAIEnemies.SetActive (false);
        }
        foreach (GameObject enemy in _twoAIEnemies)
        {
            if (enemy.activeInHierarchy == true)
                enemy.SetActive(false);
        }
    }
    private bool GetAIState()
    { return YG.SavesYG.GetInt("AIActive") == 1; }
    private void SetAIState(bool value)
    { YG.SavesYG.SetInt("AIActive", value ? 1 : 0); }
    private bool GetTwoAIState()
    { return YG.SavesYG.GetInt("TwoAIActive") == 1; }
    private void SetTwoAIState(bool value)
    { YG.SavesYG.SetInt("TwoAIActive", value ? 1 : 0); }
}
