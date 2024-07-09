using UnityEngine;

public class ChangeHat : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] _hats;
    private GameObject currentHat;

    public void PutHat()
    {
        if (currentHat != null)
        {
            currentHat.SetActive(false);
        }
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
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
