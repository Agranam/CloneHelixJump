using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Controls _controls;
    [SerializeField] private LevelCreator _levelManagment;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _resumeButton;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private OpenCloseMenu _openCloseMenu;
    [SerializeField] private ScoreCalculation _scoreCalculation;
    [SerializeField] private Player _player;


    public enum StateGame
    {
        Menu,
        Playing,
        Pause,
        Won,
        Loss,
    }

    public StateGame CurrentState;

    private void Update()
    {
        if (CurrentState == StateGame.Playing && _restartButton) _restartButton.SetActive(false);
        if (CurrentState == StateGame.Playing && _resumeButton) _resumeButton.SetActive(false);
        if (CurrentState == StateGame.Playing && _nextButton) _nextButton.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState == StateGame.Playing)
                GamePause();
            else if (CurrentState == StateGame.Pause)
                ResumeGame();
        }
    }

    public void StartLevel()
    {
        _player.enabled = true;
        CurrentState = StateGame.Playing;
        _levelManagment.CreateLevel();
        _controls.FindLevel();
        _scoreCalculation.ResetLevelScore();
        _controls.enabled = true;
    }
    public void GamePause()
    {
        CurrentState = StateGame.Pause;
        _resumeButton.SetActive(true);
        _openCloseMenu.OpenMenu();
        _controls.enabled = false;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        CurrentState = StateGame.Playing;
        _openCloseMenu.CloseMenu();
        _controls.enabled = true;
        Time.timeScale = 1f;
    }
    public void EscapeGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        if (CurrentState != StateGame.Playing) return;
        CurrentState = StateGame.Loss;
        _controls.enabled = false;
        Invoke("delayGameOver", 2f);
    }
    private void delayGameOver()
    {
        _restartButton.SetActive(true);
        _openCloseMenu.OpenMenu();
        _openCloseMenu.LostLevel();
        _player.enabled = false;
    }
    public void PlayerFinished()
    {
        if (CurrentState != StateGame.Playing) return;
        CurrentState = StateGame.Won;
        CurrentLevel++;
        _scoreCalculation.SetTotalScore();
        _controls.enabled = false;
        Invoke("delayPlayerFinished", 2f);
        if (CurrentLevel == 99)
        {
            _openCloseMenu.GameComplete();
        }
        else
        {
            _openCloseMenu.LevelComplete();
        }
    }
    public void delayPlayerFinished()
    {
        _openCloseMenu.OpenMenu();
        _nextButton.SetActive(true);

    }
    static public int CurrentLevel
    {
        get => PlayerPrefs.GetInt("CurrentLevelKey", 1);
        set
        {
            PlayerPrefs.SetInt("CurrentLevelKey", value);
            PlayerPrefs.Save();
        }
    }
}
