using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    private PersistentManagaer persist;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        //defined in select scene
        persist = GameObject.Find("PersistentData").GetComponent<PersistentManagaer>();
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
