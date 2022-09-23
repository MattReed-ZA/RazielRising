using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator crossFadeObj;
    int buildIndex = -1;
    string gameSceneName = "GameScene";
    //public Slider progressBar;

    public void fadeToLevel(string sceneName)
    {
        gameSceneName = sceneName;
        buildIndex = -1;

        if(crossFadeObj.gameObject.activeSelf && crossFadeObj.isActiveAndEnabled)
        {
            crossFadeObj.SetTrigger("StartCrossFade");
        }
        else{
            Debug.Log("This is the animator state in LevelLoader: " + crossFadeObj.gameObject.activeSelf);
            gameObject.SetActive(true);
            crossFadeObj.SetTrigger("StartCrossFade");
        }
    }

    public void fadeToNextLevel(int index)
    {
        buildIndex = index;
        gameSceneName = "";

        if(crossFadeObj.gameObject.activeSelf && crossFadeObj.isActiveAndEnabled)
        {
            crossFadeObj.SetTrigger("StartCrossFade");
        }
        else{
            Debug.Log("This is the animator state in LevelLoader: " + crossFadeObj.gameObject.activeSelf);
            gameObject.SetActive(true);
            crossFadeObj.SetTrigger("StartCrossFade");
        }
    }

    public void fade(int index)
    {
        buildIndex = index;
        gameSceneName = "";
        crossFadeObj.SetTrigger("StartCrossFade");
    }

    public void onFadeComplete()
    {
        if(buildIndex != -1)
        {
            SceneManager.LoadScene(buildIndex);
        }

        if(gameSceneName != "")
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }


    /* public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int i)
    {
        crossFadeObj.SetTrigger("StartCrossFade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(i);
    }

    //Code To Be Used Later in Life
    IEnumerator LoadAsyncronously(int i)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(i);

        crossFadeObj.SetTrigger("PlayCrossFadeAnimation");

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;

            yield return null;
        }

        crossFadeObj.SetTrigger("StartCrossFade");
    } */
}
