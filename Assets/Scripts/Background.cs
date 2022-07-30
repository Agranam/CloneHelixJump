using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Image _backgroundImages;
    [SerializeField] private Sprite[] _backgroundSprites;

    private void Awake()
    {
        ChangeBackground(ChangeLevelColors.LevelSkin);
    }

    public void ChangeBackground(int index)
    {
        _backgroundImages.sprite = _backgroundSprites[index];
    }
}
