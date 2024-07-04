using UnityEngine;

public class ChangeHat : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] _hats;
    [SerializeField] private Transform _transform;

    public void PutHat()
    {
        GameObject selectedHat = null;
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
        for (int i = 0; i < _hats.Length; i++)
        {
            if (i == selectedSkin)
            {
                selectedHat = _hats[i];
                Instantiate(selectedHat, _transform.position, Quaternion.identity);
            }
        }
    }
}
