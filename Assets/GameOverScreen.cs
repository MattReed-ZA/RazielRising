using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private bool _fadein = false;
    private bool _fadeout = false;

    public float speed = 1f;

    [SerializeField] private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        if (_fadein)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime * speed;

                if (canvasGroup.alpha >= 0.5)
                {
                    //Debug.Log("IN");
                    _fadein = false;
                }
            }
        }

        if (_fadeout)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime * speed;

                if (canvasGroup.alpha == 0)
                {
                    //Debug.Log("OUT");
                    _fadeout = false;
                }
            }
        }

    }

    public void FadeIn()
    {
        _fadein = true;
    }

    public void FadeOut()
    {
        _fadeout = true;
    }

    public void setUp()
    {
        //Debug.Log("yes");

        StartCoroutine(WaitToShow());

    }

    private IEnumerator WaitToShow()
    {
        //Debug.Log("wait");
        FadeIn();
        yield return new WaitForSeconds(0.1f);
        FadeOut();
        //yield return null;
    }

}
