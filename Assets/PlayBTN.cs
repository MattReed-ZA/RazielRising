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
        levelLoadr.LoadNextLevel(); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
