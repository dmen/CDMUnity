using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class IntroManager : MonoBehaviour
{
    private CanvasGroup logo;
    private CanvasGroup developing;
    private CanvasGroup title;
    private CanvasGroup rule;
    private CanvasGroup subText;
    private CanvasGroup super1;
    private CanvasGroup super2;

    private CanvasGroup startButton;
    private CanvasGroup skipButton;
    private CanvasGroup skip;

    private GameObject startBase;
    private GameObject skipBase;

    private AudioSource vo;

    private bool voComplete;

    private Material vidMat;



    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        voComplete = false;

        logo = GameObject.Find("luxLogo").GetComponent<CanvasGroup>();
        developing = GameObject.Find("developing").GetComponent<CanvasGroup>();
        title = GameObject.Find("title").GetComponent<CanvasGroup>();
        rule = GameObject.Find("rule").GetComponent<CanvasGroup>();

        subText = GameObject.Find("subText").GetComponent<CanvasGroup>();
        super1 = GameObject.Find("sup1").GetComponent<CanvasGroup>();
        super2 = GameObject.Find("sup2").GetComponent<CanvasGroup>();

        startBase = GameObject.Find("buttonStart");
        skipBase = GameObject.Find("buttonSkip");

        startButton = GameObject.Find("buttonStart").GetComponent<CanvasGroup>();
        skipButton = GameObject.Find("buttonSkip").GetComponent<CanvasGroup>();
        skip = GameObject.Find("skip").GetComponent<CanvasGroup>();

        vo = GameObject.Find("VO").GetComponent<AudioSource>();

        vidMat = GameObject.Find("vidShow").GetComponent<Renderer>().material;
        vidMat.color = new Color(1, 1, 1, 0);

        logo.alpha = 0;
        developing.alpha = 0;
        title.alpha = 0;
        rule.alpha = 0;
        subText.alpha = 0;
        super1.alpha = 0;
        super2.alpha = 0;
        startButton.alpha = 0;
        skipButton.alpha = 0;
        skip.alpha = 0;

        startBase.SetActive(false);
        skipBase.SetActive(false);

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
        LeanTween.value(startBase, setVidColor, new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), .5f);
        GameObject.Find("vidShow").GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    void fadeOutVideo()
    {
        LeanTween.value(startBase, setVidColor, new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), 1f).setOnComplete(showThings);
    }
    void setVidColor(Color val)
    {
        vidMat.color = val;
    }


    void showThings()
    { 
        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(developing, 1f, .5f).setDelay(.5f);
        LeanTween.alphaCanvas(title, 1f, .5f).setDelay(1f);
        LeanTween.alphaCanvas(rule, 1f, .5f).setDelay(1.2f);

        LeanTween.alphaCanvas(subText, 1f, 1f).setDelay(1.5f);
        LeanTween.alphaCanvas(super1, 1f, 1f).setDelay(1.5f);
        LeanTween.alphaCanvas(super2, 1f, 1f).setDelay(1.5f);
        
        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
        LeanTween.alphaCanvas(skipButton, 1f, 2f).setDelay(2.5f);
        LeanTween.alphaCanvas(skip, 1f, 2f).setDelay(2.5f);

        LeanTween.delayedCall(4f, startVO);

        startBase.SetActive(true);//responds to gaze now
        skipBase.SetActive(true);
    }

    /*
    private void Update()
    {
        if (!voComplete)
        {
            float progress = Mathf.Clamp01(vo.time / vo.clip.length);
            if (progress == 1f)
            {
                voComplete = true;                
            }
        }
    }
    */


    //called from StartButtonScript
    public void introComplete()
    {
        SceneManager.LoadScene(1);//hall
    }


    void startVO()
    {
        vo.Play();
    }

}
