using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private Slider _musicValeuSlider;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip[] _gameMusic;
    private List<AudioClip> _playMusic = new List<AudioClip>();

    private float musicValue
    {
        get => PlayerPrefs.GetFloat("MusicValue", 0.3f);
        set
        {
            PlayerPrefs.SetFloat("MusicValue", value);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        addToList();
        SetMusicValue(musicValue);
        _musicValeuSlider.value = musicValue;
    }
    private void Update()
    {
        if (!_audio.isPlaying)
        {
            AudioClip playing = GetRandomClip(_playMusic.Count);
            _audio.clip = playing;
            _audio.Play();
            _playMusic.Remove(playing);
        }
        if (_playMusic.Count == 0)
        {
            addToList();
        }
    }
    public void SetMusicValue(float value)
    {
        musicValue = value;
        _audio.volume = Mathf.Lerp(0f, 0.2f, value);
    }
    private void addToList ()
    {
        for (int i = 0; i < _gameMusic.Length; i++)
        {
            _playMusic.Add(_gameMusic[i]);
        }
    }
    private AudioClip GetRandomClip(int arrayLenght)
    {
        return _playMusic[Random.Range(0, arrayLenght)];
    }
}
