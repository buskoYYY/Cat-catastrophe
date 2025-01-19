using UnityEngine;

[CreateAssetMenu(fileName = "SkinManager", menuName = "Skin manager")]
public class SkinManager : ScriptableObject
{
    [Header("Elements")]
    [SerializeField] public Skin[] skins;

    [Header("Const")]
    private const string Prefix = "Skin_";

    public void SelectSkin(int skinIndex) => YG.SavesYG.SetInt("SelectedSkin", skinIndex);

    public Skin GetSelectedSkin()
    {
        int skinIndex = YG.SavesYG.GetInt("SelectedSkin", 0);
        if (skinIndex >= 0 && skinIndex < skins.Length)
            return skins[skinIndex];
        else
            return null;
    }
    public void Unlock(int skinIndex) => YG.SavesYG.SetInt(Prefix + skinIndex, 1); 

    public bool IsUnlocked(int skinIndex) => YG.SavesYG.GetInt(Prefix + skinIndex, 0) == 1; 
}
