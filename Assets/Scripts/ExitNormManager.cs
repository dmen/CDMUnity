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

    private Material vidMat;


    void Start()
    {
        man = GameObject.Find("Manager");

        logo = GameObject.Find("luxLogo").GetComponent<CanvasGroup>();

        mainText = GameObject.Find("mainText").GetComponent<CanvasGroup>();

        startButton = GameObject.Find("buttonExit").GetComponent<CanvasGroup>();
      
        logo.alpha = 0;
        mainText.alpha = 0;
        startButton.alpha = 0;

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
        LeanTween.alphaCanvas(logo, 1f, 2f);
        LeanTween.alphaCanvas(mainText, 1f, 1f).setDelay(.5f);

        LeanTween.alphaCanvas(startButton, 1f, 2f).setDelay(2f);
    }


    public void doQuit()
    {
        SceneManager.LoadScene(0);//vr/norm selector
    }

    void setVidColor(Color val)
    {
        vidMat.color = val;
    }

}
