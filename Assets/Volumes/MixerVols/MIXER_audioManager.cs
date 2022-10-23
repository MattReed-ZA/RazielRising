using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MIXER_audioManager : MonoBehaviour
{
    public static MIXER_audioManager instance;

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    [SerializeField] AudioMixer mixer; 

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume() //vol saved in vol settings
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 0.75f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 0.75f);

        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}
