using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrganizer : MonoBehaviour
{
    [Header("Settings")]
    private int _currentScene;
    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(_currentScene);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentScene + 1);
    }
}
