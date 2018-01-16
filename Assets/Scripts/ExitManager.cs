using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public void doReplay()
    {
        SceneManager.LoadScene(1);//hall
    }

    public void doExit()
    {
        SceneManager.LoadScene(0);//intro
    }

}
