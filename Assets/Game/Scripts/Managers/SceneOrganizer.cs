using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrganizer : MonoBehaviour
{
    public static SceneOrganizer instance;

    [Header("Settings")]
    private int _currentScene;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);

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
