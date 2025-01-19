using UnityEngine;
using UnityEngine.UI;

public class SelectedSkin : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image _selectedSkin;
    [SerializeField] private SkinManager _skinManager;

    private void Update()
    {
        DisPlaySelectedSkin();
    }
    private void DisPlaySelectedSkin() => _selectedSkin.sprite = _skinManager.GetSelectedSkin().sprite;
}
