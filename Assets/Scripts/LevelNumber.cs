using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] Text _currentLevelText;
    [SerializeField] Text _nextLevelText;

    public void ChangeLevel(int curentLevel)
    {
        _currentLevelText.text = (curentLevel).ToString();
        _nextLevelText.text = (curentLevel + 1).ToString();

        if (curentLevel >= 99)
        {
            _currentLevelText.fontSize = 45;
            _nextLevelText.fontSize = 45;
        }
    }

    public void updateLevel()
    {
        _currentLevelText.text = Game.CurrentLevel.ToString();
        _nextLevelText.text = (Game.CurrentLevel + 1).ToString();
    }
}
