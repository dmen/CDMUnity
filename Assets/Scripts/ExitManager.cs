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

        CanvasGroup c = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        LeanTween.alphaCanvas(c, 1.0f, 2f);
    }
   
    public void doExit()
    {
        SceneManager.LoadScene(0);//intro
    }

 }
