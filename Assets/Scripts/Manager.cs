using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;

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

    private AudioManager audioManager;

    private Material blurMat;
    private Material gridMat;


    void Start()
    {
        thePlayer = GameObject.Find("Player");//Main camera is a child
        pathToFollow = GameObject.Find("PathForCamera").GetComponent<EditorPath>();
        theLights = GameObject.FindGameObjectsWithTag("aLight");

        eyeVideoScreen = GameObject.Find("videoScreen");
        eyeVideoScreen.SetActive(false);

        audioManager = GetComponent<AudioManager>();

        hallProbe = GameObject.Find("hallProbe").GetComponent<ReflectionProbe>();
        //roomProbe = GameObject.Find("roomProbe").GetComponent<ReflectionProbe>();

        blurMat = GameObject.Find("blurImage").GetComponent<Image>().material;
        gridMat = GameObject.Find("grid").GetComponent<Renderer>().material;

        hallProbe.RenderProbe();
        //roomProbe.RenderProbe();

        currentPathNodeIndex = 1;
        //last node will give us time of flight to the next node
        lastNodeData = pathToFollow.pathNodes[currentPathNodeIndex - 1].GetComponent<NodeData>();
        //data from the node the camera will move TO
        nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();
        normalLightLevel();
        moveToNextNode();        
    }


    void setLightLevel(float newLightLevel, float changeTime)
    {
        //current light intensity
        float oldLevel = theLights[0].GetComponent<Light>().intensity;

        LeanTween.color(GameObject.Find("ceilingUpper"), new Color(Mathf.Clamp01(newLightLevel), Mathf.Clamp01(newLightLevel), Mathf.Clamp01(newLightLevel), 1f), changeTime);
        LeanTween.color(GameObject.Find("hallFloor"), new Color(Mathf.Clamp01(newLightLevel), Mathf.Clamp01(newLightLevel), Mathf.Clamp01(newLightLevel), 1f), changeTime);

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
        if (nextNodeData.nodeName == "intro")
        {
            audioManager.playAudio("audIntro", introComplete);//introComplete function will be called when audio is finished
        }

       

        if (nextNodeData.nodeName == "eyeStart")
        {
            GameObject.Find("introDoor").GetComponent<Animator>().SetTrigger("closeDoor");

            eyeVideoScreen.GetComponent<VideoPlayer>().Play();
            eyeVideoScreen.SetActive(true);

            //video screen at 0,3,.4 - to start - above player - this lets white flash happen where it can't be seen
            LeanTween.moveLocalY(eyeVideoScreen, 0f, 0f).setDelay(.2f);

            //TODO: this will be based on VO timing...
            LeanTween.delayedCall(8.7f, brightTheLights);
            LeanTween.delayedCall(10.7f, normalLightLevel);
            LeanTween.delayedCall(13.5f, addBlur);

            LeanTween.delayedCall(20f, removeBlur);
        }

        //entrance to room
        if (nextNodeData.nodeName == "door")
        {
            eyeVideoScreen.GetComponent<VideoPlayer>().Stop();
            eyeVideoScreen.SetActive(false);

            //open door - animation event at end of clip will call nodeWaitComplete()
            GameObject.Find("hallDoor").GetComponent<Animator>().SetTrigger("openDoor");
            normalLightLevel();
        }


        if (nextNodeData.nodeName == "enterRoom")
        {
            //dim the lights
            setLightLevel(.1f, 2f);
            GameObject.Find("hallDoor").GetComponent<Animator>().SetTrigger("closeDoor");
            audioManager.playAudio("aud7", vo2Complete);//vo2Complete is emty
            gridNormal();
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
            nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();
        }
        
    }


    //callback from AudioManager when intro VO completes
    void introComplete()
    {
        //this will call introDoorWaitComplete when finished - by trigger on anim clip
        GameObject.Find("introDoor").GetComponent<Animator>().SetTrigger("openDoor");
    }
    //audio manager callback
    void vo2Complete()
    {

    }

    void normalLightLevel()
    {
        setLightLevel(.9f, 2f);
    }
    void brightTheLights()
    {
        setLightLevel(2.4f, .5f);
    }

    void addBlur()
    {
        LeanTween.value(thePlayer, setBlur, 0f, 4f, 1f);        
    }

    void removeBlur()
    {
        LeanTween.value(thePlayer, setBlur, 4f, 0f, 1f);
        moveToNextNode();
        audioManager.playAudio("aud6", vo2Complete);
        LeanTween.moveLocalY(eyeVideoScreen, 3f, 0f).setDelay(.2f);//move back above player
    }

    void setBlur(float val)
    {
        blurMat.SetFloat("_BlurSize", val);
        blurMat.SetFloat("_Lightness", 0f - (val * .25f));
    }


    //GRID
    void gridNormal()
    {
        // _V_WIRE_Color,            _Color            _V_WIRE_Size
        LeanTween.value(thePlayer, setWireCol, new Color(.012f, .324f, .828f), new Color(0, 0, 0), 3f);
        LeanTween.value(thePlayer, setGridCol, new Color(0,0,0), new Color(1,1,1), 3f);
        LeanTween.value(thePlayer, setWireSize, 4.26f, 1f, 3f);
    }
    void setWireCol(Color col)
    {
        gridMat.SetColor("_V_WIRE_Color", col);
    }
    void setGridCol(Color col)
    {
        gridMat.SetColor("_Color", col);
    }
    void setWireSize(float s)
    {
        gridMat.SetFloat("_V_WIRE_Size", s);
    }


    /**
     * Called from HallDoor.cs
     */
    public void hallDoorWaitComplete()
    {
        //door has been opened - dim the lights and proceed
        if (nextNodeData.nodeName == "door")
        {
           // setLightLevel(.2f, 2f);
        }
       
        moveToNextNode();
    }


    /**
     * Called from IntroDoor.cs
     */
    public void introDoorWaitComplete()
    {
        audioManager.playAudio("aud2", vo2Complete);
        moveToNextNode();
    }


}
