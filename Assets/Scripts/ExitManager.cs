using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ExitManager : MonoBehaviour
{
    private Material vidMat;
    private GameObject thePlayer;

    private void Start()
    {
        GvrCardboardHelpers.Recenter();

        thePlayer = GameObject.Find("Player");

        vidMat = GameObject.Find("vidShow").GetComponent<Renderer>().material;
        vidMat.color = new Color(1, 1, 1, 0);

        LeanTween.delayedCall(1f, startVideo);
    }   

    public void doReplay()
    {
        SceneManager.LoadScene(1);//hall
    }

    public void doExit()
    {
        SceneManager.LoadScene(0);//intro
    }

    void startVideo()
    {
        GameObject.Find("introVideo").GetComponent<VideoPlayer>().Play();
        LeanTween.delayedCall(.25f, moveVideoDown);
        LeanTween.delayedCall(3f, fadeOutVideo);
    }

    void moveVideoDown()
    {
        LeanTween.value(thePlayer, setVidColor, new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), .5f);
        GameObject.Find("vidShow").GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    void fadeOutVideo()
    {
        LeanTween.value(thePlayer, setVidColor, new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), 1f).setOnComplete(showStuff);
    }
    void setVidColor(Color val)
    {
        vidMat.color = val;
    }
    void showStuff()
    {
        CanvasGroup c = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(c, 1.0f, 2f);
    }
}
