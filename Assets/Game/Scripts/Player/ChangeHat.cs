using UnityEngine;

public class ChangeHat : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] _hats;
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _playerPos;
    private GameObject currentHat;

    [Header("Settings")]
    [SerializeField] private Vector3 _hatAdjustment = new Vector3(1, 1, 1);

    private void Update()
    {
        if (currentHat != null)
        {
            currentHat.transform.position = _playerPos.position + _hatAdjustment;
        }
    }
    public void PutHat()
    {
        if (currentHat != null)
        {
            Destroy(currentHat);
        }
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
        for (int i = 0; i < _hats.Length; i++)
        {
            if (i == selectedSkin)
            {
                currentHat = _hats[i];
                currentHat = Instantiate(currentHat, _transform.position, Quaternion.identity);
            }
        }
    }
}
