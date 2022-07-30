using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Platform CurrentPlatform;
    [SerializeField] private float _bounceSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Game _game;
    [SerializeField] private SoundsEffects _soundsEffects;
    private Renderer _currentRenderer;

    private void OnEnable()
    {
        GetRenderer();
        setTransparency(1);
    }

    public void GetRenderer()
    {
        _currentRenderer = GetComponent<Renderer>();
    }

    public void Bounce()
    {
        _soundsEffects.BounceAudio();
        _rigidbody.velocity = new Vector3(0, _bounceSpeed, 0);
    }

    public void Died()
    {
        _soundsEffects.LoseAudio();
        _rigidbody.velocity = Vector3.zero;
        StartEffectDissolving(0.33f);
        _game.GameOver();
    }
    public void Finished()
    {
        _soundsEffects.WinAudio();
        _rigidbody.velocity = Vector3.zero;
        _game.PlayerFinished();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Platform>() || other.GetComponent<PlatformsGenerator>())
        {
            _soundsEffects.PassedAudio();
        }
    }
    private void StartEffectDissolving(float time)
    {
        StartCoroutine(Dissolving(time));
    }

    private IEnumerator Dissolving(float time)
    {
        for (float t = 0.8f; t > 0; t -= Time.deltaTime * time)
        {
            setTransparency(t);
            yield return null;
        }
    }
    private void setTransparency(float value)
    {
        _currentRenderer.material.SetFloat("_Transparency", value);
    }
}
