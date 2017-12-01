﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Manager : MonoBehaviour
{
    private EditorPath pathToFollow;
    private GameObject thePlayer;
    private int currentPathNodeIndex;

    private GameObject[] theLights;

    private ReflectionProbe hallProbe;
    private ReflectionProbe roomProbe;

    private GameObject eyeVideoScreen;//rect attached to camera
    private NodeData lastNodeData;
    private NodeData nextNodeData;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        thePlayer = GameObject.Find("Player");//Main camera is a child
        pathToFollow = GameObject.Find("PathForCamera").GetComponent<EditorPath>();
        theLights = GameObject.FindGameObjectsWithTag("aLight");

        eyeVideoScreen = GameObject.Find("videoScreen");
        eyeVideoScreen.SetActive(false);

        hallProbe = GameObject.Find("hallProbe").GetComponent<ReflectionProbe>();
        //roomProbe = GameObject.Find("roomProbe").GetComponent<ReflectionProbe>();

        hallProbe.RenderProbe();
        //roomProbe.RenderProbe();

        currentPathNodeIndex = 1;

        //last node will give us time of flight to 
        lastNodeData = pathToFollow.pathNodes[currentPathNodeIndex - 1].GetComponent<NodeData>();
        //data from the node the camera will move TO
        nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();
        moveToNextNode();        
    }


    void setLightLevel(float newLightLevel, float changeTime)
    {
        //current light intensity
        float oldLevel = theLights[0].GetComponent<Light>().intensity;

        LeanTween.color(GameObject.Find("ceilingUpper"), new Color(newLightLevel, newLightLevel, newLightLevel, 1f), changeTime);
        LeanTween.color(GameObject.Find("hallFloor"), new Color(newLightLevel, newLightLevel, newLightLevel, 1f), changeTime);

        LeanTween.value(thePlayer, setLights, oldLevel, newLightLevel, changeTime);
    }


    void setLights(float val)
    {
        foreach(GameObject l in theLights)
        {
            l.GetComponent<Light>().intensity = val;
        }

        //need to re-render the probes so the reflection is dimmed
        hallProbe.RenderProbe();
        //roomProbe.RenderProbe();
    }


    /**
     * Tweens the camera to the next node
     * Calls nodeReached() when complete
     */
    void moveToNextNode()
    {
        LeanTween.move(thePlayer, pathToFollow.pathNodes[currentPathNodeIndex].transform.position, lastNodeData.timeToNextNode).setEase(lastNodeData.ease ? LeanTweenType.easeInOutQuad : LeanTweenType.linear).setOnComplete(nodeReached);                
    }


    /**
     * Node tween is complete
     * we've arrvied at next node
     */
    void nodeReached()
    {
        if(nextNodeData.nodeName == "eyeStart")
        {           
            eyeVideoScreen.GetComponent<VideoPlayer>().Play();
            eyeVideoScreen.SetActive(true);
        }


        if (nextNodeData.nodeName == "door")
        {
            eyeVideoScreen.GetComponent<VideoPlayer>().Stop();
            eyeVideoScreen.SetActive(false);

            //open door - animation event at end of clip will call
            GameObject.Find("hallDoor").GetComponent<Animator>().SetTrigger("openDoor");
        }

        currentPathNodeIndex++;
        lastNodeData = nextNodeData;
        if (!nextNodeData.waitAtNode)
        {
            if (currentPathNodeIndex < pathToFollow.pathNodes.Count)
            {                
                nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();
                moveToNextNode();
            }
        }
        else
        {

        }
        
    }


    public void nodeWaitComplete()
    {
        nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();
        moveToNextNode();
    }
    

}
