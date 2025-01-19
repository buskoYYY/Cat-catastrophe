using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YandexAd : MonoBehaviour
{
    [SerializeField] private YandexGame _sdk;

    public void PriseAdShow()
    {
        _sdk._RewardedShow(1);
    }
}
