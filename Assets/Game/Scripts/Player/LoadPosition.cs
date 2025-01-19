using System.Collections;
using UnityEngine;

public class LoadPosition : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private PlayerPositionData _playerLoadPos;

    [Header("Setting")]
    [SerializeField] float timeReloadController = .1f;
    private CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        characterController.enabled = false;
        transform.position = _playerLoadPos.LoadPlayerPosition();
        StartCoroutine(SetActiveController());
    }

    IEnumerator SetActiveController()
    {
        yield return new WaitForSeconds(timeReloadController);
        characterController.enabled = true;
    }
}

