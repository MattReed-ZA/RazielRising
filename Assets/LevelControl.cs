using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    public Animator crossFadeObj;
    //public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            LoadNextLevel();            
        }
        else
        {

        }
    }

    public void LoadNextLevel()
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
    /* IEnumerator LoadAsyncronously(int i)
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
