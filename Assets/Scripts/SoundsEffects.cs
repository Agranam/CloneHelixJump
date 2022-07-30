using UnityEngine;
using UnityEngine.UI;

public class SoundsEffects : MonoBehaviour
{
    // 0 - bounce, 1 - passed, 2 - loss, 3 - completed
    [SerializeField] private AudioSource[] _allGameSounds; 
    [SerializeField] private AudioClip[] _originalSounds;
    [SerializeField] private AudioClip[] _updatedSounds;
    [SerializeField] private Slider _soundValeuSlider;

    private float soundValue
    {
        get => PlayerPrefs.GetFloat("SoundValue", 0.3f);
        set
        {
            PlayerPrefs.SetFloat("SoundValue", value);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        ChangeSounds(ChangeLevelColors.LevelSkin);
        SetSoundValue(soundValue);
        _soundValeuSlider.value = soundValue;
    }

    public void ChangeSounds(int index)
    {
        if (index == 0)
            setSounds(_originalSounds);
        if (index == 1)
            setSounds(_updatedSounds);
    }

    private void setSounds(AudioClip[] currentSounds)
    {
        for (int i = 0; i < _allGameSounds.Length; i++)
        {
            _allGameSounds[i].clip = currentSounds[i];
        }
    }

    public void SetSoundValue(float value)
    {
        soundValue = value;
        float curentValue = Mathf.Lerp(0f, 0.4f, value);
        for (int i = 0; i < _allGameSounds.Length; i++)
        {
            _allGameSounds[i].volume = curentValue;
        }
    }
    public void BounceAudio()
    {
        _allGameSounds[0].Play();
    }
    public void PassedAudio()
    {
        _allGameSounds[1].Play();
    }
    public void LoseAudio()
    {
        _allGameSounds[2].Play();
    }
    public void WinAudio()
    {
        _allGameSounds[3].Play();
    }
}
