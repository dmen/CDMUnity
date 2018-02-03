using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonContinue : MonoBehaviour
{
    public Image progressImage;

    bool isEntered = false;
    float timeElapsed = 0f;
    float GazeActivationTime = 2f;

    ISIManager manager;


    void Start()
    {
        manager = GameObject.Find("theManager").GetComponent<ISIManager>();
    }


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

                manager.begin();
            }
        }
        else
        {
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
