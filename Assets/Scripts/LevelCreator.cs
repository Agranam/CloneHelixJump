using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject _levelGeneratorPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelNumber _levelNumber;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private ChangeLevelColors _changeLevelColors;
    private GameObject _createdLevel;

    private void Awake()
    {
        PlayerDisabled();
    }

    public void CreateLevel()
    {
        if (_createdLevel)
            DistroyLevel();
        _levelNumber.ChangeLevel((int)Game.CurrentLevel);
        _createdLevel = Instantiate(_levelGeneratorPrefab, transform);
        _changeLevelColors.ChangeMaterials(ChangeLevelColors.LevelSkin);
        PlayerEnabled();
        _progressBar.gameObject.SetActive(true);
        _progressBar.ResetProgressBar();
    }
    public void DistroyLevel()
    {
        Destroy(_createdLevel);
    }
    public void PlayerEnabled()
    {
        _player.transform.position = new Vector3(0f, 4, -5);
        _player.SetActive(true);
    }
    public void PlayerDisabled()
    {
        _player.SetActive(false);
    }
}
