using UnityEngine;
using UnityEngine.UI;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] private SkinsShop _skinsShop;
    [SerializeField] private Button[] _purchasedSkins;
    [SerializeField] private Toggle[] _setToggle;

    public void SetToggleSkin()
    {
        _setToggle[CurrentSkin].isOn = true;
    }

    public void CheckPurchasedSkins()
    {
        _skinsShop.LoadPurchasedSkins();
        for (int i = 0; i < _purchasedSkins.Length; i++)
        {
            if (_skinsShop._openSkins[i])
            {
                _purchasedSkins[i].enabled = false;
                _setToggle[i].interactable = true;
            }
        }
    }

    public int CurrentSkin
    {
        get => PlayerPrefs.GetInt("CurrentSkin", 10);
        set
        {
            PlayerPrefs.SetInt("CurrentSkin", value);
            PlayerPrefs.Save();
        }
    }

}
