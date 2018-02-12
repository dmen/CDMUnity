using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PersistentManagaer : MonoBehaviour
{
    bool _skip = false;
    bool _vr = false;

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

    public bool vr
    {
        get
        {
            return _vr;
        }
        set
        {
            _vr = value;
        }
    }
}
