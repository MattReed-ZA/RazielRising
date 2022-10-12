using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBTN : MonoBehaviour
{
    public LevelLoader levelLoadr;
    [SerializeField] AudioSource audio;

    public void PlayGame()
    {
        audio.Play();
        levelLoadr.fadeToNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        audio.Play();
        Application.Quit();
    }
}
