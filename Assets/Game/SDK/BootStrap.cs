using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YaAssets;
using YG;

public class BootStrap : MonoBehaviour
{
    private IEnumerator  Start()
    {
        while(YandexGame.SDKEnabled == false)
        {
            yield return null;
        }
        Localization.InitTranslations();
        SceneManager.LoadScene(1);
    }
}
