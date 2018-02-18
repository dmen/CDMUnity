using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

/*
 * Attached to Manager in scene: exitNorm
 */
public class ExitNormManager : MonoBehaviour
{
    private CanvasGroup logo;
    private CanvasGroup mainText;
    private CanvasGroup vidCan;

    private CanvasGroup startButton;
    private GameObject man;


    void Start()
    {
        man = GameObject.Find("Manager");
        logo = GameObject.Find("luxLogo").GetComponent<CanvasGroup>();
        mainText = GameObject.Find("mainText").GetComponent<CanvasGroup>();
        startButton = GameObject.Find("buttonExit").GetComponent<CanvasGroup>();

        vidCan = GameObject.Find("vid").GetComponent<CanvasGroup>();
        vidCan.alpha = 0;

        logo.alpha = 0;
        mainText.alpha = 0;
        startButton.alpha = 0;

        LeanTween.delayedCall(.5f, startVideo);
    }


    void startVideo()
    {
        GameObject.Find("introVideo").GetComponent<VideoPlayer>().Play();
        LeanTween.delayedCall(.25f, moveVideoDown);
        LeanTween.delayedCall(3f, fadeOutVideo);
    }


    void moveVideoDown()
    {
        LeanTween.alphaCanvas(vidCan, 1f, .5f);
    }


    void fadeOutVideo()
    {
        LeanTween.alphaCanvas(vidCan, 0f, .5f).setOnComplete(showThings);
    }


    void showThings()
    {
        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(mainText, 1f, 1f).setDelay(.5f);

        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
    }

    //called by clicking quit button 
    public void doQuit()
    {
        SceneManager.LoadScene(2);//phone mode main menu
    }
    

}
