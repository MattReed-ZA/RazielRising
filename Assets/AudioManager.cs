using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    [SerializeField] public AudioMixerGroup audioMixer;
    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume=s.volume;

            s.source.loop=s.loop;
            s.source.outputAudioMixerGroup = audioMixer;
        }
    }

    public void Play(string name)
    {
        Sound s=Array.Find(sounds,sound=>sound.name==name);
        s.source.Play();

        if(s==null)
        {
            Debug.LogWarning("Sound :"+ name +"not found");
        }
    }

    public void Stop(string name)
    {
        Sound s=Array.Find(sounds,sound=>sound.name==name);
        s.source.Stop();
    }
}
