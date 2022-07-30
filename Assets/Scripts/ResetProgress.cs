using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    [SerializeField] private LevelNumber _levelNumber;
    [SerializeField] private ScoreCalculation _scoreCalculation;

    public void ProgressReset()
    {
        PlayerPrefs.DeleteAll();
        Game.CurrentLevel = 1;
        ScoreCalculation.TotalScore = 0;
        _levelNumber.updateLevel();
        _scoreCalculation.updateScore();
    }
}
