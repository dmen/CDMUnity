using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    private EditorPath pathToFollow;
    private GameObject thePlayer;
    private int currentPathNodeIndex;

    private GameObject[] theLights;

    private ReflectionProbe hallProbe;
    private ReflectionProbe roomProbe;

    private GameObject eyeVideoScreen;
    private GameObject footVideoScreen;//footSteps
    private Material footVideoMat;//for fading the video in/out

    private NodeData lastNodeData;
    private NodeData nextNodeData;

    private AudioManager audioManager;

    private GameObject blurCanvas;
    private Material blurMat;

    private ArrowManager arrowManager;
    private GridObjectsManager gridObjectsManager;
    private LuxMeterManager luxMeterManager;

    //these are all children of starCanvas on the Camera
    private GameObject theStars;
    private GameObject coverLeft;
    private GameObject coverRight;
   
    private ErrorHUDManager errorHud;
    private bool userSkipped;

    private bool inTheRoom;//when true the hall probe doesnt get updated

    void Start()
    {
        GvrCardboardHelpers.Recenter();

        //userSkipped = false;//TESTING
        userSkipped = GameObject.Find("PersistentData").GetComponent<PersistentManagaer>().skip;

        errorHud = GameObject.Find("errorHUD").GetComponent<ErrorHUDManager>();

        thePlayer = GameObject.Find("Player");//Main camera is a child
        pathToFollow = GameObject.Find("PathForCamera").GetComponent<EditorPath>();
        theLights = GameObject.FindGameObjectsWithTag("aLight");
        
        eyeVideoScreen = GameObject.Find("videoScreen");
        eyeVideoScreen.SetActive(false);

        footVideoScreen = GameObject.Find("videoScreenFeet");
        footVideoMat = footVideoScreen.GetComponent<Renderer>().material;
        footVideoMat.color = new Color(1, 1, 1, 0);
        footVideoScreen.SetActive(false);

        audioManager = GetComponent<AudioManager>();

        hallProbe = GameObject.Find("hallProbe").GetComponent<ReflectionProbe>();
        roomProbe = GameObject.Find("roomProbe").GetComponent<ReflectionProbe>();

        blurCanvas = GameObject.Find("blurImage");
        blurMat = blurCanvas.GetComponent<Image>().material;

        arrowManager = GameObject.Find("arrows").GetComponent<ArrowManager>();
        gridObjectsManager = GameObject.Find("gridObjects").GetComponent<GridObjectsManager>();
        luxMeterManager = GameObject.Find("LUXMeter").GetComponent<LuxMeterManager>();

        inTheRoom = false;
        hallProbe.RenderProbe();//probe set to scripted update
        roomProbe.RenderProbe();

        //starCanvas
        theStars = GameObject.Find("theStars");
        theStars.GetComponent<CanvasGroup>().alpha = 0;
        theStars.SetActive(false);
        coverLeft = GameObject.Find("coverLeft");
        coverRight = GameObject.Find("coverRight");
        coverLeft.GetComponent<CanvasGroup>().alpha = 0;
        coverRight.GetComponent<CanvasGroup>().alpha = 0;
        coverLeft.SetActive(false);
        coverRight.SetActive(false);

        luxMeterManager.hideMeter(true);
        errorHud.hideHUD(true);
        blurCanvas.SetActive(false);
        LeanTween.delayedCall(2f, openIntroDoor);
        normalLightLevel();

        if(userSkipped)
        {
            inTheRoom = true;
            //User skipped to LUX levels - only play lux info
            currentPathNodeIndex = 6;
            //last node will give us time of flight to the next node
            lastNodeData = pathToFollow.pathNodes[currentPathNodeIndex - 1].GetComponent<NodeData>();
            //data from the node the camera will move TO
            nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();

            thePlayer.transform.position = pathToFollow.pathNodes[currentPathNodeIndex - 1].transform.position;
            LeanTween.delayedCall(1f, gridObjectsManager.showItAll);
            upTheArrow();
            LeanTween.delayedCall(1.2f, arrowManager.showArrows10);
           // LeanTween.delayedCall(4.2f, upTheArrow);
            LeanTween.delayedCall(1.5f, playAud15);
        }
        else
        {
            currentPathNodeIndex = 1;
            //last node will give us time of flight to the next node
            lastNodeData = pathToFollow.pathNodes[currentPathNodeIndex - 1].GetComponent<NodeData>();
            //data from the node the camera will move TO
            nextNodeData = pathToFollow.pathNodes[currentPathNodeIndex].GetComponent<NodeData>();

            moveToNextNode();
        }
        
    }    

    void openIntroDoor()
    {
        GameObject.Find("introDoor").GetComponent<Animator>().SetTrigger("openDoor");
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
        foreach (GameObject l in theLights)
        {
            l.GetComponent<Light>().intensity = val;
        }

        //need to re-render the probes so the reflection is modified
        if (!inTheRoom)
        {
            hallProbe.RenderProbe();
        }
        else
        {
            roomProbe.RenderProbe();
        }
    }


    /**
     * Tweens the camera to the next node
     * Calls nodeReached() when complete
     */
    void moveToNextNode()
    {
        LeanTween.move(thePlayer, pathToFollow.pathNodes[currentPathNodeIndex].transform.position, lastNodeData.timeToNextNode).setEase(lastNodeData.ease ? LeanTweenType.easeInOutQuad : LeanTweenType.linear).setOnComplete(nodeReached);                
    }

    void vo4()
    {
        audioManager.playAudio("vo_4", vo2Complete);//12.5sec
    }
    void vo5()
    {
        audioManager.playAudio("vo_5", vo2Complete);//12.5sec
    }

    /**
     * Node tween is complete
     * we've arrvied at next node
     */
    void nodeReached()
    {
        if (nextNodeData.nodeName == "intro")
        {
            audioManager.playAudio("vo_1", introComplete);//introComplete function will be called when audio is finished
        }       

        if (nextNodeData.nodeName == "eyeStart")
        {
            GameObject.Find("introDoor").GetComponent<Animator>().SetTrigger("closeDoor");

            eyeVideoScreen.GetComponent<VideoPlayer>().Play();
            eyeVideoScreen.SetActive(true);

            //video screen at 0,3,.4 - to start - above player - this lets white flash happen where it can't be seen
            LeanTween.moveLocalY(eyeVideoScreen, .14f, 0f).setDelay(.25f);

            //audio
            audioManager.playAudio("vo_3", vo2Complete);//12.5sec
            LeanTween.delayedCall(8.6f, vo4);
            LeanTween.delayedCall(13.5f, vo5);

            LeanTween.delayedCall(3.8f, addTheStars);
            LeanTween.delayedCall(4f, dimTheLights);
            LeanTween.delayedCall(7f, removeTheStars);
            LeanTween.delayedCall(7f, normalLightLevel);
            LeanTween.delayedCall(8.7f, brightTheLights);
            LeanTween.delayedCall(9.7f, dimTheLights);
            LeanTween.delayedCall(11f, normalLightLevel);
            LeanTween.delayedCall(14f, addBlur);

            LeanTween.delayedCall(21f, removeBlur);
        }

        //entrance to room
        if (nextNodeData.nodeName == "door")
        {
            eyeVideoScreen.GetComponent<VideoPlayer>().Stop();
            eyeVideoScreen.SetActive(false);
            blurCanvas.SetActive(false);
        }


        if (nextNodeData.nodeName == "enterRoom")
        {
            inTheRoom = true;
            roomProbe.RenderProbe();

            GameObject.Find("hallDoor").GetComponent<Animator>().SetTrigger("closeDoor");

            //we built this course from the ground up...
            audioManager.playAudio("vo_7", playAud8);//12.5sec

            //gridObjectsManager.showGrid();//this is a bit earlier now

            LeanTween.delayedCall(6.5f, arrowManager.showArrows10);
        }


        if (nextNodeData.nodeName == "courseStart")
        {
            //to begin individuals went through 40 min of dark adaptation
            audioManager.playAudio("vo_28", playAud29);//7.6sec
            LeanTween.delayedCall(4f, addRightEyeCover);
        }

        if (nextNodeData.nodeName == "stopTimer")
        {
            errorHud.stopTimer();
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
        Debug.Log("introcomplete");
    }


    //audio manager callback
    void vo2Complete()
    {

    }


    //audioManager callback - called when aud7 is finished
    void gridIntroComplete()
    {
       // normalLightLevel();
        //add the arrows
        
        LeanTween.delayedCall(4f, playAud8);
    }


    //we added objects of varying height and contrast... to simulate
    void playAud8()
    { 
        audioManager.playAudio("vo_8", playAud9);//11.5sec
        LeanTween.delayedCall(5.5f, addTheNoodle);
    }
    void addTheNoodle()
    {
        gridObjectsManager.showNoodle();
    }

    //foam circle on labstand / bush
    void playAud9()
    {
        audioManager.playAudio("vo_9", playAud10);//9.9sec
        gridObjectsManager.showFoamCircle();
    }
    //there was also a stop sign
    void playAud10()
    {
        LeanTween.delayedCall(4.5f, gridObjectsManager.stopDown);//move stopsign down then back up
        audioManager.playAudio("vo_10", playAud11);//6.8sec
        gridObjectsManager.showStopSign();
    }

    //black squares represented holes in the ground
    void playAud11()
    {
        audioManager.playAudio("vo_11", playAud12);//3.3sec
        gridObjectsManager.showBlackHoles();
    }
    //astroturf as grassy patches
    void playAud12()
    {
        audioManager.playAudio("vo_12", playAud13);//2.7sec
        gridObjectsManager.showGrass();
    }
    //and raised blocks to mimick a step...
    void playAud13()
    {
        audioManager.playAudio("vo_13", playAud14);//3.7sec
        gridObjectsManager.showRaisedBlocks();
        LeanTween.delayedCall(1f, upTheArrow);
    }
    void upTheArrow()
    {
        GameObject g = GameObject.Find("arrowc10spec");
        Vector3 pos = g.transform.position;
        pos.y += .0517f;
        g.transform.position = pos;
        //
        GameObject g2 = GameObject.Find("arrowc10spec2");
        pos = g2.transform.position;
        pos.y += .0517f;
        g2.transform.position = pos;
    }
    //additional objects were added...
    void playAud14()
    {
        audioManager.playAudio("vo_14", playAud15);//7.5sec
        gridObjectsManager.showRemaining();
    }
    
    //LUX CHAPTER
    //to siumlate the real world... lux levels
    //begin to build lux meter
    void playAud15()
    {
        if (userSkipped)
        {
            audioManager.playAudio("luxLevelIntro", playAud16);//24.6
            LeanTween.delayedCall(18f, luxMeterManager.showMeter);//show meter at 'we added 7 different lux levels'
        }
        else
        {
            audioManager.playAudio("vo_15", playAud16);//21.2sec
            LeanTween.delayedCall(4f, luxMeterManager.showMeter);//show meter at 'we added 7 different lux levels'
        }
    }

    //the 7 lux levels ranged from 1 to 400
    void playAud16()
    {        
        audioManager.playAudio("vo_16", playAud17);//3.5sec
    }
    //400 lux, the brightest setting... office
    void playAud17()
    {
        audioManager.playAudio("vo_17", playAud18, "sfx_office", 4f);//4.8sec
        luxMeterManager.lux400();
        setLightLevel(.9f, 2f);
    }
    //250 lux, mimicked interior of elevator
    void playAud18()
    {
        audioManager.playAudio("vo_18", playAud19, "sfx_elevator", 3.2f);//4.3sec
        luxMeterManager.lux250();
        setLightLevel(.75f, 2f);
    }
    //the next level, 125 lux mimicked interior of train car at night
    void playAud19()
    {
        audioManager.playAudio("vo_19", playAud20, "sfx_trainCar", 7f);//4.3sec
        luxMeterManager.lux125();
        setLightLevel(.52f, 2f);
    }
    //50 lux, an outdoor train station at night - trains passing
    void playAud20()
    {
        audioManager.playAudio("vo_20", playAud21, "sfx_trainPassing", 4f);//3.3sec
        luxMeterManager.lux50();
        setLightLevel(.36f, 2f);
    }
    //10 lux, a city one hour after sunset
    void playAud21()
    {
        audioManager.playAudio("vo_21", playAud22, "sfx_city", 4f);//4.06sec
        luxMeterManager.lux10();
        setLightLevel(.25f, 2f);
    }
    //4 lux was equivalent to a parking lot at night
    void playAud22()
    {
        audioManager.playAudio("vo_22", playAud23, "sfx_carDoor", 3.5f);//3.1sec
        luxMeterManager.lux4();
        setLightLevel(.1f, 2f);
    }
    //1 lux, darkest - moonless summer night
    void playAud23()
    {
        audioManager.playAudio("vo_23", playAud24, "sfx_summerNight", 4.5f);//4.8sec
        luxMeterManager.lux1();
        setLightLevel(.05f, 2f);
    }

    //each lux level assigned score code
    void playAud24()
    {
        //lux meter chapter is just the 400 - 1 explanation
        //userSkipped = false; //TESTING
        if (userSkipped)
        {
            //thank you for visiting our lab
            normalLightLevel();
            luxMeterManager.noLux(true);
            audioManager.playAudio("vo_35", showEnding);//6.15sec
        }
        else
        {
            luxMeterManager.showScores();
            normalLightLevel();
            luxMeterManager.noLux();
            audioManager.playAudio("vo_24", playAud25);//10.2sec
        }        
    }

    //to make sure individuals didn't memorize...
    void playAud25()
    {
        luxMeterManager.hideMeter();
        audioManager.playAudio("vo_25", playAud26);//6.2sec

        //12 sep VO starts 4 sec in
        LeanTween.delayedCall(4f, arrowManager.hideArrows10);
        LeanTween.delayedCall(4.5f, gridObjectsManager.doShuffle);
        LeanTween.delayedCall(7f, arrowManager.showArrows5);//c10 down in 2 sec - c5 back up at 4sec
        //waits for ~3sec then shows 11
        LeanTween.delayedCall(11f, arrowManager.hideArrows5);
        LeanTween.delayedCall(14f, arrowManager.showArrows11);
        LeanTween.delayedCall(19f, arrowManager.hideArrows11);
        LeanTween.delayedCall(22f, arrowManager.showArrows10);
    }

    //called from gridObjectsManager once shuffle is complete
    public void bringBackArrows()
    {        
        arrowManager.killExtras();//sets active false on arrow groups 5 and 11
    }

    //A validation study was performed
    void playAud26()
    {
        audioManager.playAudio("vo_26", playAud27);//19.6sec
    }
    //OK, now let's take a walk through the course
    void playAud27()
    {
        audioManager.playAudio("vo_27", vo2Complete);//3.15sec

        moveToNextNode();//will move to node courseStart - and play aud28
    }
    //completed a new configuration with the other eye patched
    void playAud29()
    {
        removeRightEyeCover();
        addLeftEyeCover();
        audioManager.playAudio("vo_29", playAud30);//3.4sec
        moveToNextNode();
    }
    //and then again using both eyes
    void playAud30()
    {
        removeLeftEyeCover();
        audioManager.playAudio("vo_30", playAud31);//9.75sec
    }
    //to ensure consistent evaluation every test...
    void playAud31()
    {
        audioManager.playAudio("vo_31", playAud32);//19.13sec
    }

    //individuals were graded based on accuracy - did they collide...
    //error hud appears - ~29 sec of audio until it hides
    void playAud32()
    {
        errorHud.showHUD();
        audioManager.playAudio("vo_32", playAud33);//13.2sec
        LeanTween.delayedCall(4f, errorHud.showError1);
        LeanTween.delayedCall(6f, errorHud.showError2);
        LeanTween.delayedCall(8f, errorHud.showError3);
        LeanTween.delayedCall(10f, errorHud.showError4);
    }
    //in order to pass they had to complete the course...
    void playAud33()
    {
        audioManager.playAudio("vo_33", playAud34);//7.6sec

        LeanTween.delayedCall(2f, errorHud.speedUp);//multiplies delta time to make timer reach 3min faster       
    }

    //this allowed us to compare the lowest level..
    void playAud34()
    {
        audioManager.playAudio("vo_34", playAud35);//7.14sec
    }

    //thank you for visiting our lab
    void playAud35()
    {
        errorHud.hideHUD();
        LeanTween.delayedCall(2f, delayedEndAudio);
    }
    void delayedEndAudio()
    { 
        audioManager.playAudio("vo_35", showEnding);//6.15sec
    }

    void normalLightLevel()
    {
        setLightLevel(1f, 2f);
    }
    void brightTheLights()
    {
        setLightLevel(2.8f, .5f);
    }
    void dimTheLights()
    {
        setLightLevel(.2f, .5f);
    }
    void showEnding()
    {
        SceneManager.LoadScene(3);//exit scene
    }
    void addTheStars()
    {       
        theStars.SetActive(true);
        LeanTween.value(thePlayer, setStarLevel, 0f, .5f, 1f);
    }
    void removeTheStars()
    {
        LeanTween.value(thePlayer, setStarLevel, .5f, 0f, 1f).setOnComplete(turnOffStars);
    }
    void turnOffStars()
    {
        theStars.SetActive(false);
    }
    void setStarLevel(float val)
    {
        theStars.GetComponent<CanvasGroup>().alpha = val;
    }
    //EYE COVERS
    void addRightEyeCover()
    {
        coverRight.SetActive(true);
        LeanTween.value(thePlayer, setRightCover, 0f, 1f, 1f);
    }
    void removeRightEyeCover()
    {
        LeanTween.value(thePlayer, setRightCover, 1f, 0f, 1f).setOnComplete(turnOffRightEyeCover);
    }
    void turnOffRightEyeCover()
    {
        coverRight.SetActive(false);
    }
    void addLeftEyeCover()
    {
        coverLeft.SetActive(true);
        LeanTween.value(thePlayer, setLeftCover, 0f, 1f, 1f);
    }
    void removeLeftEyeCover()
    {
        LeanTween.value(thePlayer, setLeftCover, 1f, 0f, 1f).setOnComplete(turnOffLeftEyeCover);
    }
    void turnOffLeftEyeCover()
    {
        coverLeft.SetActive(false);
    }
    void setRightCover(float val)
    {
        coverRight.GetComponent<CanvasGroup>().alpha = val;
    }
    void setLeftCover(float val)
    {
        coverLeft.GetComponent<CanvasGroup>().alpha = val;
    }

    void addBlur()
    {
        blurCanvas.SetActive(true);
        LeanTween.value(thePlayer, setBlur, 0f, 3f, 1f);        
    }

    void removeBlur()
    {
        LeanTween.value(thePlayer, setBlur, 3f, 0f, 1f);
        moveToNextNode();

        audioManager.playAudio("vo_6", vo2Complete);//46 sec

        //open door at 30 sec
        LeanTween.delayedCall(29f, openTheDoor);
        //and then begin showing the grid...
        LeanTween.delayedCall(42f, showTheGrid);

        //open door - animation event at end of clip will call hallDoorWaitComplete()
        //GameObject.Find("hallDoor").GetComponent<Animator>().SetTrigger("openDoor");            
        LeanTween.delayedCall(18f, playFootVid);
        LeanTween.moveLocalY(eyeVideoScreen, 3f, 0f).setDelay(.2f);//move back above player
    }
    void showTheGrid()
    {
        gridObjectsManager.showGrid();
    }
    void openTheDoor()
    {
        //open door - animation event at end of clip will call hallDoorWaitComplete()
        GameObject.Find("hallDoor").GetComponent<Animator>().SetTrigger("openDoor");
    }
    void playFootVid()
    {
        footVideoScreen.SetActive(true);
        fadeInFootVid();
        footVideoScreen.GetComponent<VideoPlayer>().Play();
        LeanTween.moveLocalY(footVideoScreen, 0f, 0f).setDelay(.25f);
        LeanTween.delayedCall(3f, fadeOutFootVid);
    }
    void fadeInFootVid()
    {
        LeanTween.value(thePlayer, setVidColor, new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), .5f);
    }
    void fadeOutFootVid()
    {
        LeanTween.value(thePlayer, setVidColor, new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), .5f).setOnComplete(killFootVid);
    }
    void setVidColor(Color val)
    {
        footVideoMat.color = val;
    }
    void killFootVid()
    {
        footVideoScreen.SetActive(false);
    }
    void setBlur(float val)
    {
        blurMat.SetFloat("_BlurSize", val);
        blurMat.SetFloat("_Lightness", 0f - (val * .25f));
    }
    

    /**
     * Called from HallDoor.cs
     */
    public void hallDoorWaitComplete()
    {
        //door has been opened - dim the lights and proceed        
       // setLightLevel(.1f, 5f);
        //moveToNextNode();
    }


   


}
