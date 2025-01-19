using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _scale;

    [Header("Settings")]
    [SerializeField] private float _delayLoadScene = 1.5f;
    private int _currentScene;
    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void Loading()
    {
        _loadingScreen.SetActive(true);
       StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(_currentScene + 1);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            _scale.value = loadAsync.progress;
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(_delayLoadScene);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
