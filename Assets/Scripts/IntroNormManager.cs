﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroNormManager : MonoBehaviour
{
    private PersistentManagaer persist;
    private CanvasGroup bg;

    private CanvasGroup logo;
    private CanvasGroup mainText;

    private CanvasGroup startButton;
    private CanvasGroup skipButton;
    private GameObject man;

    private Material vidMat;


    void Start()
    {
        man = GameObject.Find("Manager");

        //defined in select scene
        //persist = GameObject.Find("PersistentData").GetComponent<PersistentManagaer>();

        bg = GameObject.Find("bg").GetComponent<CanvasGroup>();

        logo = GameObject.Find("luxLogo").GetComponent<CanvasGroup>();

        mainText = GameObject.Find("mainText").GetComponent<CanvasGroup>();

        startButton = GameObject.Find("buttonStart").GetComponent<CanvasGroup>();
        skipButton = GameObject.Find("buttonSkip").GetComponent<CanvasGroup>();

        bg.alpha = 0;
        logo.alpha = 0;
        mainText.alpha = 0;
        startButton.alpha = 0;
        skipButton.alpha = 0;

        vidMat = GameObject.Find("vidShow").GetComponent<Image>().material;
        vidMat.color = new Color(1, 1, 1, 0);

        LeanTween.delayedCall(1f, startVideo);
    }


    void startVideo()
    {
        GameObject.Find("introVideo").GetComponent<VideoPlayer>().Play();
        LeanTween.delayedCall(.25f, moveVideoDown);
        LeanTween.delayedCall(3f, fadeOutVideo);
    }


    void moveVideoDown()
    {
        LeanTween.value(man, setVidColor, new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), .5f);
        GameObject.Find("vidShow").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }


    void fadeOutVideo()
    {        
        LeanTween.value(man, setVidColor, new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), 1f).setOnComplete(showThings);
    }


    void showThings()
    {
        LeanTween.alphaCanvas(bg, 1f, 1f);

        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(mainText, 1f, 1f).setDelay(.5f);

        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
        LeanTween.alphaCanvas(skipButton, 1f, 2f).setDelay(2.5f);        
    }


    public void exploreEndpoint()
    {
        persist.skip = false;
        SceneManager.LoadScene(1);//ISI Text
    }

    void setVidColor(Color val)
    {
        vidMat.color = val;
    }


    public void skipToLUX()
    {
        persist.skip = true;
        SceneManager.LoadScene(1);//ISI Text
    }
}