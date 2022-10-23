using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SepVolSlider_audiosettings : MonoBehaviour
{

    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private float backgroundFloat, soundEffectsFloat;
    public Slider backgroundSlider, soundEffectsSlider;


    // ----------
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    //public AudioClip backgroundAudio;
    //public AudioClip[] soundEffectsAudio;
    // ----------


    
    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
    
}
