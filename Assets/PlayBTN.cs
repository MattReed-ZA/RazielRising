using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class PlayBTN : MonoBehaviour
{
    public LevelLoader levelLoadr;

    public void PlayGame()
    {
        levelLoadr.fadeToNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
