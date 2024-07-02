using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _textShopPanel;
    [SerializeField] private Sprite[] _soundImage;
    [SerializeField] protected Image _image;


    void Update()
    {
        _text.text = ScoreManager.instance.GetScore().ToString();
        _textShopPanel.text = ScoreManager.instance.GetScore().ToString();
    }
}

