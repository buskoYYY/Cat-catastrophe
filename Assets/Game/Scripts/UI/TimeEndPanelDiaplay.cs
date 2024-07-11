using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEndPanelDiaplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ThirdPersonController _thirdPersonController;
    [SerializeField] private GameObject _timeEndPanel;

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
    }

    private void CloseTimeEndPanel()
    {
        _timeEndPanel.SetActive(false);
        _thirdPersonController.MoveEnable();
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
