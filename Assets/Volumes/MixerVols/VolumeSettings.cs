using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";
    

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

       
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value)*20);       

    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);

    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(MIXER_audioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(MIXER_audioManager.SFX_KEY, sfxSlider.value);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(MIXER_audioManager.MUSIC_KEY, 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat(MIXER_audioManager.SFX_KEY, 0.75f);
    }
}
