using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeparateVolSliders : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private int firstPlayint;
    private float backgroundFloat, soundEffectsFloat;
    public Slider backgroundSlider, soundEffectsSlider;
    


    // ----------
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    //public AudioClip backgroundAudio;
    //public AudioClip[] soundEffectsAudio;
    // ----------


    
    void Start()
    {
        firstPlayint = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayint == 0)
        {
            backgroundFloat = .75f;
            soundEffectsFloat = 0.75f;

            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;

            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundsettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    void OnApplicationfocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundsettings();
        }
    }

    // ----------
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
    

}