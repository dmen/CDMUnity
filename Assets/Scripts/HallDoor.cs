using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallDoor : MonoBehaviour
{
    private Manager theManager;

    void Start()
    {
        theManager = GameObject.Find("theManager").GetComponent<Manager>();
    }


    /**
     * Called by animation event attached to hallDoorOpen clip
     */
    void doorIsOpen()
    {
        theManager.nodeWaitComplete();
    }
	
}
