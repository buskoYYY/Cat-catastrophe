using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite[] _soundImage;
    [SerializeField] private Image _image;
    [SerializeField] private ScoreManager _scoreManager; 


    void Update()
    {
        _text.text = _scoreManager.GetScore().ToString();
    }

}

