using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Text _levelScoreText;

    private int _levelScore;

    private void Start()
    {
        updateScore();
    }

    static public int TotalScore
    {
        get => PlayerPrefs.GetInt("CurrentScore", 0);
        set
        {
            PlayerPrefs.SetInt("CurrentScore", value);
            PlayerPrefs.Save();
        }
    }

    public void SetLevelScore(int badSectors, int goodSectors)
    {
        _levelScore = _levelScore + badSectors * 2 + goodSectors;
        updateScore();
    }
    public void SetTotalScore()
    {
        TotalScore = TotalScore + _levelScore;
        ResetLevelScore();
    }
    public void ResetLevelScore()
    {
        _levelScore = 0;
        updateScore();
    }
    public void updateScore()
    {
        _totalScoreText.text = TotalScore.ToString();
        _levelScoreText.text = "POINTS: " + _levelScore.ToString();
    }
}
