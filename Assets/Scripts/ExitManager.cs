using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/*
 * Attached to Manager in scene: exit (VR)
 */
public class ExitManager : MonoBehaviour
{
    private Material vidMat;
    private GameObject thePlayer;
    private GameObject startBase;
    private CanvasGroup screen;


    private void Start()
    {
        GvrCardboardHelpers.Recenter();

        screen = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        startBase = GameObject.Find("buttonStart");

        vidMat = GameObject.Find("vidShow").GetComponent<Renderer>().material;
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
        LeanTween.alphaCanvas(screen, 1f, 2f);
    }

    //called by gaze selecting the exit button
    //called from ExitButtonScript
    public void doExit()
    {
        SceneManager.LoadScene(1);//vr mode main menu
    }

 }
