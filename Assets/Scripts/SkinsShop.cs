using UnityEngine;

public class SkinsShop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SkinsPanel _skinsPanel;
    [SerializeField] private ScoreCalculation _scoreCalculation;
    [SerializeField] private Material[] _playerSkins;
    [SerializeField] public bool[] _openSkins;
    [SerializeField] private int[] _priceSkins;
    [SerializeField] private GameObject _notEnoughScore;

    private void Start()
    {
        setSkin(_skinsPanel.CurrentSkin);
    }
    public void buySkin(int indexMaterial)
    {
        if (ScoreCalculation.TotalScore >= _priceSkins[indexMaterial])
        {
            openSkin(indexMaterial);
            ScoreCalculation.TotalScore = ScoreCalculation.TotalScore - _priceSkins[indexMaterial];
            SavePurchasedSkins(indexMaterial);
            _skinsPanel.CheckPurchasedSkins();
            _scoreCalculation.updateScore();
        }
        else
        {
            _notEnoughScore.SetActive(true);
        }
    }

    public void setSkin(int indexMaterial)
    {
        _player.GetComponent<Renderer>().material = _playerSkins[indexMaterial];
        _player.GetRenderer();
        _skinsPanel.CurrentSkin = indexMaterial;
    }

    private void openSkin(int indexMaterial)
    {
        _openSkins[indexMaterial] = true;
    }

    public void SavePurchasedSkins(int indexMaterial)
    {
        int currentSkin = _openSkins[indexMaterial] == true ? 1 : 0;
        PlayerPrefs.SetInt("Skin" + indexMaterial, currentSkin);
        PlayerPrefs.Save();
    }

    public void LoadPurchasedSkins()
    {
        for (int i = 1; i < _openSkins.Length - 1; i++)
        {
            if (PlayerPrefs.HasKey("Skin" + i))
            {
                _openSkins[i] = true;
            }
            else
            {
                _openSkins[i] = false;
            }
        }
    }
}
