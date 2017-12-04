﻿using UnityEngine;
using UnityEngine.UI;

public class SkipButtonScript : MonoBehaviour
{
    public Image progressImage; // add an image as child to your button object and set its image type to Filled. Assign it to this field in inspector.
    bool isEntered = false;
    float timeElapsed = 0f;
    float GazeActivationTime = 1.5f;


    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp01(timeElapsed / GazeActivationTime);
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                progressImage.fillAmount = 0;
                isEntered = false;
            }
        } else {
            timeElapsed = 0;
        }
    }


    public void OnGazeEnter(string s)
    {
        isEntered = true;
    }


    public void OnGazeExit(string s)
    {
        isEntered = false;
        progressImage.fillAmount = 0;
    }
}
