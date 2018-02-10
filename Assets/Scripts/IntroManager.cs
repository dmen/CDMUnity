using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class IntroManager : MonoBehaviour
{
    private CanvasGroup bg;

    private CanvasGroup logo;
    private CanvasGroup mainText;

    private CanvasGroup startButton;
    private CanvasGroup skipButton;
    private CanvasGroup skip;

    private GameObject startBase;
    private GameObject skipBase;

    private AudioSource vo;
    
    private Material vidMat;

    private PersistentManagaer persist;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        GvrCardboardHelpers.Recenter();

        persist = GameObject.Find("PersistentData").GetComponent<PersistentManagaer>();

        bg = GameObject.Find("bg").GetComponent<CanvasGroup>();

        logo = GameObject.Find("luxLogo").GetComponent<CanvasGroup>();
       
        mainText = GameObject.Find("mainText").GetComponent<CanvasGroup>();

        startBase = GameObject.Find("buttonStart");
        skipBase = GameObject.Find("buttonSkip");

        startButton = GameObject.Find("buttonStart").GetComponent<CanvasGroup>();
        skipButton = GameObject.Find("buttonSkip").GetComponent<CanvasGroup>();
        skip = GameObject.Find("skip").GetComponent<CanvasGroup>();

        vo = GameObject.Find("VO").GetComponent<AudioSource>();

        vidMat = GameObject.Find("vidShow").GetComponent<Renderer>().material;
        vidMat.color = new Color(1, 1, 1, 0);

        bg.alpha = 0;
        logo.alpha = 0;
        mainText.alpha = 0;
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
        LeanTween.value(startBase, setCamColor, new Color(1, 1, 1, 1), new Color(0, .54902f, .57647f, 1f), 2f);
        LeanTween.value(startBase, setVidColor, new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), 1f).setOnComplete(showThings);
    }


    void setVidColor(Color val)
    {
        vidMat.color = val;
    }

    void setCamColor(Color val)
    {
        Camera.main.backgroundColor = val;
    }


    void showThings()
    { 
        LeanTween.alphaCanvas(bg, 1f, 1f);

        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(mainText, 1f, 1f).setDelay(.5f);
        
        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
        LeanTween.alphaCanvas(skipButton, 1f, 2f).setDelay(2.5f);
        LeanTween.alphaCanvas(skip, 1f, 2f).setDelay(2.5f);

        //LeanTween.delayedCall(4f, startVO);

        startBase.SetActive(true);//responds to gaze now
        skipBase.SetActive(true);
    }

  


    //called from StartButtonScript
    public void introComplete(bool doSkip = false)
    {
        persist.skip = doSkip;
        SceneManager.LoadScene(1);//ISI Text
    }


    void startVO()
    {
        vo.Play();
    }

}
