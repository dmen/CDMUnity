using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//used in Intro scene to keep user choice
public class PersistentManagaer : MonoBehaviour
{
    bool _skip = false;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    public bool skip
    {
        get
        {
            return _skip;
        }
        set
        {
            _skip = value;
        }
    }
}
