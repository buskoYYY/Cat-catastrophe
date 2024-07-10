using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image _selectedSkin;
    [SerializeField] private SkinManager _skinManager;
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Update()
    {
        _coinText.text = PlayerPrefs.GetInt("coins").ToString();
        _selectedSkin.sprite = _skinManager.GetSelectedSkin().sprite;
    }
}
