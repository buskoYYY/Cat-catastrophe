using UnityEngine;

[CreateAssetMenu(fileName = "SkinManager", menuName = "Skin manager")]
public class SkinManager : ScriptableObject
{
    [Header("Elements")]
    [SerializeField] public Skin[] skins;

    [Header("Const")]
    private const string Prefix = "Skin_";

    public void SelectSkin(int skinIndex) => PlayerPrefs.SetInt("SelectedSkin", skinIndex);

    public Skin GetSelectedSkin()
    {
        int skinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (skinIndex >= 0 && skinIndex < skins.Length)
            return skins[skinIndex];
        else
            return null;
    }
    public void Unlock(int skinIndex) => PlayerPrefs.SetInt(Prefix + skinIndex, 1); 

    public bool IsUnlocked(int skinIndex) => PlayerPrefs.GetInt(Prefix + skinIndex, 0) == 1; 
}
