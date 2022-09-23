using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public PlayerController player;

    public static Scene currentScene;
    [SerializeField] GameObject SkipTutorialBtn;
    [SerializeField] GameObject SkipBtn;
    [SerializeField] GameObject LoadBtn;

    public LevelLoader levelLoadr;    

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //Debug.Log(sceneName);

        if (sceneName != "GameScene")//load skip button only for tutorial
        {
            SkipTutorialBtn.SetActive(false);
        }
        else{
            SkipBtn.SetActive(true);
        }

        string path = Application.persistentDataPath + "/player.data";

        if(File.Exists(path))
        {
            LoadBtn.SetActive(true);
        }
        else{
            LoadBtn.SetActive(false);
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
        if(gameObject.activeSelf)
        {
            levelLoadr.fadeToLevel("MenuScene");
        }
        else{
            Debug.Log("This is the animator state in PauseMenuController: " + gameObject.activeSelf);
        }

        //SceneManager.LoadScene("MenuScene");
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void SkipTutorial()
    {
        if(gameObject.activeSelf)
        {
            levelLoadr.fadeToLevel("GameScene 1");
        }
        else{
            Debug.Log("This is the animator state in PauseMenuController: " + gameObject.activeSelf);
        }

        //SceneManager.LoadScene("GameScene 1");
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}
