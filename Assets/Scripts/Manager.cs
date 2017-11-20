using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{
    private EditorPathScript pathToFollow;
    private GameObject thePlayer;
    private int currentPathNodeIndex = 0;

    private GameObject[] theLights;

    private ReflectionProbe hallProbe;
    private ReflectionProbe roomProbe;


    void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        thePlayer = GameObject.Find("Player");//Main camera is a child
        pathToFollow = GameObject.Find("PathForCamera").GetComponent<EditorPathScript>();
        theLights = GameObject.FindGameObjectsWithTag("aLight");

        hallProbe = GameObject.Find("hallProbe").GetComponent<ReflectionProbe>();
        roomProbe = GameObject.Find("roomProbe").GetComponent<ReflectionProbe>();

        hallProbe.RenderProbe();
        roomProbe.RenderProbe();

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
        roomProbe.RenderProbe();
    }


    void moveToNextNode()
    {
        LeanTween.move(thePlayer, pathToFollow.path_objs[currentPathNodeIndex].position, 5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(nodeReached);
    }


    void nodeReached()
    {
        currentPathNodeIndex++;

        if(currentPathNodeIndex == 2)
        {
            setLightLevel(.1f, 1f);
        }

        //turn the lights back up at the end
        if (currentPathNodeIndex == 6)//pathToFollow.path_objs.Count
        {
            setLightLevel(1f, 1f);
        }

        if (currentPathNodeIndex < pathToFollow.path_objs.Count)
        {
            moveToNextNode();
        }
    }

}
