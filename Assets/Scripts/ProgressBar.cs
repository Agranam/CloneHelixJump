using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _progressBarFill;

    private Transform _finishPlatform;
    private float _startY;
    private float _minimumReachedY;

    private void Start()
    {
        ResetProgressBar();
    }

    public void ResetProgressBar()
    {
        _finishPlatform = FindObjectOfType<FinishPlatform>().transform;
        _startY = _player.transform.position.y;
        _minimumReachedY = _startY;
    }

    private void Update()
    {
        _minimumReachedY = Mathf.Min(_minimumReachedY, _player.transform.position.y);
        float finishY = _finishPlatform.transform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + 1f, _minimumReachedY);
        _progressBarFill.fillAmount = t;
    }
}
