using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Image progressImage;

    bool isEntered = false;
    float timeElapsed = 0f;
    float GazeActivationTime = 2f;

    IntroManager manager;


    void Start()
    {
        manager = GameObject.Find("theManager").GetComponent<IntroManager>();
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

                manager.introComplete();//loads hall
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
