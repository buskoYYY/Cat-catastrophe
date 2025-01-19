using UnityEngine;

public class ChangeHat : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] _hats;
    private GameObject currentHat;

    [Header("Settings")]
    private int currentHatIndex;

    private void Start()
    {
        currentHatIndex = YG.SavesYG.GetInt("SelectedSkin");
        currentHat = _hats[currentHatIndex];
        currentHat.SetActive(true);
    }
    public void PutHat()
    {
        if (currentHat != null)
        {
            currentHat.SetActive(false);
        }
        int selectedSkin = YG.SavesYG.GetInt("SelectedSkin");
        for (int i = 0; i < _hats.Length; i++)
        {
            if (i == selectedSkin)
            {
                currentHat = _hats[i];
                currentHat.SetActive(true);
            }
        }
    }
}
