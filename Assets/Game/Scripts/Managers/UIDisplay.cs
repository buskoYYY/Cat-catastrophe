using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI _text;

    void Update()
    {
        _text.text = ScoreManager.instance.GetScore().ToString();
    }
}
