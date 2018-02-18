using UnityEngine;
using UnityEngine.UI;

/*
 * Attached to the Exit button in the exit scene - this is the VR scene
 * handles the gaze selection
 */
public class ExitButtonScript : MonoBehaviour
{
    public Image progressImage; 
    bool isEntered = false;
    float timeElapsed = 0f;
    float GazeActivationTime = 2f;

    ExitManager manager;


    void Start()
    {
        manager = GameObject.Find("theManager").GetComponent<ExitManager>();
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

                manager.doExit();
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
