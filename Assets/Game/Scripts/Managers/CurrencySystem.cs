using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [Header("Settings")]
        [SerializeField] private int _currencyPerHit;
    private int _currency = 0;

    public void ModifyCurrency(int value)
    {
        _currency += value;
    }
    public int GetCurrency()
    {
        return _currency;
    }
}
