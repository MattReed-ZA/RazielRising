using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBTN : MonoBehaviour
{
    public Animator crossFadeObj;
    public Slider progressBar;

    public void PlayGame()
    {
        LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int i)
    {
        crossFadeObj.SetTrigger("StartCrossFade");
        yield return new WaitForSeconds(2);
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
    }
}
