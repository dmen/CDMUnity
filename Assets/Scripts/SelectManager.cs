using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

//This is scene 0 - VR / Phone mode selection

public class SelectManager : MonoBehaviour
{
    private PersistentManagaer persist;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    

    void Start()
    {
        GvrCardboardHelpers.Recenter();

        //defined in select scene
        persist = GameObject.Find("PersistentData").GetComponent<PersistentManagaer>();

        StartCoroutine(startVR());
    }


    public IEnumerator startVR()
    {
        XRSettings.LoadDeviceByName("cardboard");
        yield return null;
        XRSettings.enabled = false;
    }



    public void doVR()
    {
        persist.vr = true;
        SceneManager.LoadScene(1);//vr menu
    }


    public void doNorm()
    {
        persist.vr = false;
        SceneManager.LoadScene(2);//norm menu
    }
	
}
