using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public static Scene currentScene;
    [SerializeField] GameObject btn;

    public LevelLoader levelLoadr;    

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);

        if (sceneName != "GameScene")//load skip button only for tutorial
        {
            btn.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Quit()
    {
        //levelLoadr.LoadNextLevel("MenuScene");
        SceneManager.LoadScene("MenuScene");
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void Skip()
    {
        //levelLoadr.LoadNextLevel("GameScene 1");
        SceneManager.LoadScene("GameScene 1");
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}
