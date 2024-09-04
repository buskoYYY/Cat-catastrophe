using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _currencyPerHit;
    private int _currency = 0;

    public void AddCurrency(int value)
    {
        _currency += value;
    }

    public int SubtractCurrency(int value)
    {
        _currency -= value;
        return _currency;
    }
    public int GetCurrency()
    {
        return _currency;
    }
}
