using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Restart Button in VR mode - gaze selection
//scene: intro

public class RestartButtonScript : MonoBehaviour
{
    public Image progressImage;
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

                SceneManager.LoadScene(0);//Selector
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
