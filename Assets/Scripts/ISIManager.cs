using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ISIManager : MonoBehaviour
{
    //called by clicking continue
    public void begin()
    {
        SceneManager.LoadScene(2);//Hall
    }
}
