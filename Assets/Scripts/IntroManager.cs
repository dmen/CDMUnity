using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IntroManager : MonoBehaviour
{
    private CanvasGroup logo;
    private CanvasGroup title;
    private CanvasGroup subTitle;
    private CanvasGroup subText;

    private CanvasGroup startButton;
    private CanvasGroup explore;
    private CanvasGroup skipButton;
    private CanvasGroup skip;

    private GameObject startBase;
    private GameObject skipBase;

    private AudioSource vo;

    private bool voComplete;



    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        voComplete = false;

        logo = GameObject.Find("logoImage").GetComponent<CanvasGroup>();
        title = GameObject.Find("title").GetComponent<CanvasGroup>();
        subTitle = GameObject.Find("subTitle").GetComponent<CanvasGroup>();
        subText = GameObject.Find("subText").GetComponent<CanvasGroup>();

        startBase = GameObject.Find("buttonStart");
        skipBase = GameObject.Find("buttonSkip");

        startButton = GameObject.Find("buttonStart").GetComponent<CanvasGroup>();
        explore = GameObject.Find("exploreEndpoint").GetComponent<CanvasGroup>();
        skipButton = GameObject.Find("buttonSkip").GetComponent<CanvasGroup>();
        skip = GameObject.Find("skip").GetComponent<CanvasGroup>();

        vo = GameObject.Find("VO").GetComponent<AudioSource>();

        startBase.SetActive(false);
        skipBase.SetActive(false);

        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(title, 1f, 1f).setDelay(1f);
        LeanTween.alphaCanvas(subTitle, 1f, 1f).setDelay(2f);
        LeanTween.alphaCanvas(subText, 1f, 1f).setDelay(3f).setOnComplete(startVO);
    }


    private void Update()
    {
        if (!voComplete)
        {
            float progress = Mathf.Clamp01(vo.time / vo.clip.length);
            if (progress == 1f)
            {
                voComplete = true;
                fadeInStartScreen();
            }
        }
    }


    private void fadeInStartScreen()
    {
        //fade out logo screen
        LeanTween.alphaCanvas(title, 0f, 1f);
        LeanTween.alphaCanvas(subTitle, 0f, 1f).setDelay(.5f);
        LeanTween.alphaCanvas(subText, 0f, 1f).setDelay(1f);
        LeanTween.alphaCanvas(logo, 0f, 2f).setDelay(1f);

        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
        LeanTween.alphaCanvas(explore, 1f, 2f).setDelay(2f);
        LeanTween.alphaCanvas(skipButton, 1f, 2f).setDelay(2.5f);
        LeanTween.alphaCanvas(skip, 1f, 2f).setDelay(2.5f);

       startBase.SetActive(true);//responds to gaze now
       skipBase.SetActive(true);
    }


    public void introComplete()
    {
        SceneManager.LoadScene(1);//hall
    }


    void startVO()
    {
        vo.Play();
    }

}
