using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExitSign : MonoBehaviour
{

    public Image progressImage;

    bool isEntered = false;
    float timeElapsed = 0f;
    float GazeActivationTime = 2f;
    
   
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

                SceneManager.LoadScene(0);//intro menu
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
