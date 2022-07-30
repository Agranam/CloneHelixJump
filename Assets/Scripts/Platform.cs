using UnityEngine;

public class Platform : MonoBehaviour
{
    internal ScoreCalculation _scoreCalculation;

    private void Start()
    {
        _scoreCalculation = FindObjectOfType<ScoreCalculation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }

    internal virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _scoreCalculation.SetLevelScore(0, 11);
        }
    }
}
