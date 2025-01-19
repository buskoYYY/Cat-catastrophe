using System.Collections;
using UnityEngine;

public class TimeEndPanelDiaplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ThirdPersonController _thirdPersonController;
    [SerializeField] private GameObject _timeEndPanel;
    [SerializeField] private AIActivator _aIActivator;

    [Header("Setiings")]
    [SerializeField] private float _timeToLoadPanel;

    private void OnEnable()
    {
        Timer.AcivateTimeEndPanel += OpenTimeEndPanel;
        Timer.DeacivateTimeEndPanel += CloseTimeEndPanel;
    }
    private void OpenTimeEndPanel()
    {
        StartCoroutine(LoadTimeEndScene());
        _thirdPersonController.MoveDisable();
        _aIActivator.AIDisactive();
    }

    private void CloseTimeEndPanel()
    {
        _timeEndPanel.SetActive(false);
        _thirdPersonController.MoveEnable();
        _aIActivator.AIActive();
    }

    IEnumerator LoadTimeEndScene()
    {
        yield return new WaitForSeconds(_timeToLoadPanel);
        _timeEndPanel.SetActive(true);
    }

    private void OnDisable()
    {
        Timer.AcivateTimeEndPanel -= OpenTimeEndPanel;
        Timer.DeacivateTimeEndPanel -= CloseTimeEndPanel;
    }
}
