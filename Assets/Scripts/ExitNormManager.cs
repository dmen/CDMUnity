using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ExitNormManager : MonoBehaviour
{
    private CanvasGroup logo;
    private CanvasGroup mainText;

    private CanvasGroup startButton;
    private GameObject man;


    void Start()
    {
        man = GameObject.Find("Manager");

        logo = GameObject.Find("luxLogo").GetComponent<CanvasGroup>();

        mainText = GameObject.Find("mainText").GetComponent<CanvasGroup>();

        startButton = GameObject.Find("buttonExit").GetComponent<CanvasGroup>();

        logo.alpha = 0;
        mainText.alpha = 0;
        startButton.alpha = 0;

        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(mainText, 1f, 1f).setDelay(.5f);

        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
    }


    public void doQuit()
    {
        SceneManager.LoadScene(0);//vr/norm selector
    }
    

}
