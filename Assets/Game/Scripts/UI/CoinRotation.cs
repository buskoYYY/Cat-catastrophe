using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, -.5f, 0));
    }
}
