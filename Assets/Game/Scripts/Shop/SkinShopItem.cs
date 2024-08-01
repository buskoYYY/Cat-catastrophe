using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopItem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SkinManager _skinManager;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _costText;
    private Skin _skin;

    [Header("Settings")]
    [SerializeField] private int _skinIndex;
    private void Start()
    {
        Debug.Log("Hi");
        _skin = _skinManager.skins[_skinIndex];
        GetComponent<Image>().sprite = _skin.sprite;

        if (_skinManager.IsUnlocked(_skinIndex))
        {
            _buyButton.gameObject.SetActive(false);
        }
        else
        {
            _buyButton.gameObject.SetActive(true);
            _costText.text = _skin.cost.ToString();
        }
    }

    public void OnSkinPressed()
    {
        if (_skinManager.IsUnlocked(_skinIndex))
        {
            _skinManager.SelectSkin(_skinIndex);
        }
    }

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("coins", 0);
        if (coins >= _skin.cost && !_skinManager.IsUnlocked(_skinIndex))
        {
            PlayerPrefs.SetInt("coins", coins - _skin.cost);
            _skinManager.Unlock(_skinIndex);
            _buyButton.gameObject.SetActive(false);
            _skinManager.SelectSkin(_skinIndex);
        }
        else
        {
            Debug.Log("Недостаточно денег");
        }
    }

}
