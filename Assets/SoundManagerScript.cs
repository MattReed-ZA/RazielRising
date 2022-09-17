using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip PlayerJump;
    public static AudioClip PlayerDash;
    public static AudioClip PlayerBounce;
    public static AudioClip EnterBash;
    public static AudioClip ExitBash;
    static AudioSource audiosrc;

    public static AudioClip PlayerJump1;
    public static AudioClip PlayerDash1;
    public static AudioClip PlayerBounce1;
    public static AudioClip EnterBash1;
    public static AudioClip ExitBash1;
    static AudioSource audiosrc1;
    public static Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "GameScene")
        {
            audiosrc=GetComponent<AudioSource>();

            PlayerJump=Resources.Load<AudioClip>("JumpV2");
            PlayerDash=Resources.Load<AudioClip>("Dash");
            PlayerBounce=Resources.Load<AudioClip>("Lilly Pad Bounce");
            EnterBash=Resources.Load<AudioClip>("Slow Motion Enter");
            ExitBash=Resources.Load<AudioClip>("Bash Exit");
        }
        if(scene.name == "GameScene 1")
        {
            audiosrc1=GetComponent<AudioSource>();

            PlayerJump1=Resources.Load<AudioClip>("JumpV2");
            PlayerDash1=Resources.Load<AudioClip>("Dash");
            PlayerBounce1=Resources.Load<AudioClip>("Lilly Pad Bounce");
            EnterBash1=Resources.Load<AudioClip>("ESW");
            ExitBash1=Resources.Load<AudioClip>("Bash Exit"); 
        }
        
    }

    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        if(scene.name == "GameScene")
        {
           switch(clip)
            {
                case "Jump":
                    audiosrc.PlayOneShot(PlayerJump);
                    break;
                case "Dash":
                    audiosrc.PlayOneShot(PlayerDash);
                    break;
                case "Bounce":
                    audiosrc.PlayOneShot(PlayerBounce);
                    break;
                case "EBash":
                    audiosrc.PlayOneShot(EnterBash);
                    break;
                case "BashExit":
                    audiosrc.PlayOneShot(ExitBash);
                    break;
            } 
        }
        if(scene.name == "GameScene 1")
        {
           switch(clip)
            {
                case "Jump1":
                    audiosrc1.PlayOneShot(PlayerJump1);
                    break;
                case "Dash1":
                    audiosrc1.PlayOneShot(PlayerDash1);
                    break;
                case "Bounce1":
                    audiosrc1.PlayOneShot(PlayerBounce1);
                    break;
                case "EBash1":
                    audiosrc1.PlayOneShot(EnterBash1);
                    break;
                case "BashExit1":
                    audiosrc1.PlayOneShot(ExitBash1);
                    break;
            } 
        }
        // switch(clip)
        // {
        //     case "Jump":
        //         audiosrc.PlayOneShot(PlayerJump);
        //         break;
        //     case "Dash":
        //         audiosrc.PlayOneShot(PlayerDash);
        //         break;
        //     case "Bounce":
        //         audiosrc.PlayOneShot(PlayerBounce);
        //         break;
        //     case "EBash":
        //         audiosrc.PlayOneShot(EnterBash);
        //         break;
        //     case "BashExit":
        //         audiosrc.PlayOneShot(ExitBash);
        //         break;
        // }
    }
}
