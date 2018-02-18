using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Used in scene: Hall
 * attached to both exits signs - attached to exRed image object
 * in the exit signs canvas - handles gaze selection exiting
 */

public class ExitSign : MonoBehaviour
{
    Manager theManager;

    public Image progressImage;

    bool isEntered = false;
    float timeElapsed = 0f;
    float GazeActivationTime = 2f;


    private void Start()
    {
        theManager = GameObject.Find("theManaer").GetComponent<Manager>();
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

                theManager.exitSignExit();
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
