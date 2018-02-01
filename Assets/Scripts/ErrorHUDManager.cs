using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ErrorHUDManager : MonoBehaviour
{
    GameObject mainHUD;
    CanvasGroup mainAlpha;
    Text timer;
    bool showing = false;
    float startTime;
    TimeSpan t;

    GameObject error3;//red ball indicator
    Text errorText;

    GameObject eb1;//errorBall
    GameObject eb2;
    GameObject eb3;
    GameObject eb4;
    GameObject redError;//full screen red rect
    CanvasGroup redErrorAlpha;


    void Awake ()
    {
        eb1 = GameObject.Find("errorBall1");
        eb2 = GameObject.Find("errorBall2");
        eb3 = GameObject.Find("errorBall3");
        eb4 = GameObject.Find("errorBall4");

        errorText = GameObject.Find("errorTitle").GetComponent<Text>();

        redError = GameObject.Find("redError");
        redErrorAlpha = redError.GetComponent<CanvasGroup>();

        mainHUD = transform.gameObject;

        mainAlpha = GetComponent<CanvasGroup>();
        mainAlpha.alpha = 0;

        eb1.SetActive(false);
        eb2.SetActive(false);
        eb3.SetActive(false);
        eb4.SetActive(false);

        redError.SetActive(false);//red rect that covers screen

        timer = GameObject.Find("timerText").GetComponent<Text>();        
	}


    //called from Manager.playAud32()
    //we have about 29sec of VO to count up to the end time... 3min?
    //and to show the 3 or 4 error dots and shake the camera...
    public void showHUD()
    {
        showing = true;
        startTime = 145f; //timer start time - in seconds
        mainHUD.SetActive(true);
        LeanTween.alphaCanvas(mainAlpha, 1f, 1f);
    }


    public void hideHUD(bool fast = false)
    {
        showing = false;

        if (fast)
        {
            mainAlpha.alpha = 0f;
            hide();
        }
        else
        {
            LeanTween.alphaCanvas(mainAlpha, 0f, 1f).setOnComplete(hide);
        }
    }


    void hide()
    {
        mainHUD.SetActive(false);
    }


    public void stopTimer()
    {
        showing = false;
    }

    public void showError1()
    {
        errorText.text = "ERROR 1";
        eb1.SetActive(true);
        redFlash();
    }
    public void showError2()
    {
        errorText.text = "ERROR 2";
        eb2.SetActive(true);
        redFlash();
    }
    public void showError3()
    {
        errorText.text = "ERROR 3";
        eb3.SetActive(true);
        redFlash();
    }
    public void showError4()
    {
        errorText.text = "ERROR 4";
        eb4.SetActive(true);
        redFlash();
    }

    public void redFlash()
    {
        redError.SetActive(true);
        redErrorAlpha.alpha = 1f;
        LeanTween.alphaCanvas(redErrorAlpha, 0f, .25f).setOnComplete(killRed);
    }

    private void killRed()
    {
        redError.SetActive(false);
    }

    private void Update()
    {
        if (showing)
        {
            startTime += Time.deltaTime;//seconds to complete last frame
            t = TimeSpan.FromSeconds(startTime);
            timer.text = String.Format("{0:00}:{1:00}.{2:000}", t.Minutes, t.Seconds, t.Milliseconds);
        }
    }




}
