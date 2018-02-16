using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridObjectsManager : MonoBehaviour
{
    Manager mainManager;
    
    GameObject grid;

    GameObject noodle;
    GameObject stick;

    Material noodleMat;
    Material stickMat;

    GameObject foamBall;
    GameObject shrub;
    Material bush;
    Material foam;
    Material foamRod;
    Material foamBase;

    GameObject stopSign;
    GameObject nGon;//inside the stopSign - for moving it up/down

    GameObject bh1;
    GameObject bh2;
    GameObject bh3;

    GameObject grass1;
    GameObject grass2;

    GameObject raised1;
    GameObject raised2;
    GameObject raised3;
    GameObject raised4;

    GameObject wasteBasket;
    GameObject trafficCone;
    GameObject trafficCone2;    
    GameObject doorRoom;

    Vector3 objectDestination;

    List<Vector3> c10Positions;
    List<Vector3> c5Positions;
    List<Vector3> c11Positions;
    List<Quaternion> noodleRotations;

    GameObject[] lines;



    void Start()
    {
        //for calling Manager.bringBackArrows once the shuffle is complete
        mainManager = GameObject.Find("theManager").GetComponent<Manager>();

        grid = GameObject.Find("gridLines");

        noodle = GameObject.Find("noodle");
        stick = GameObject.Find("stick");
        noodleMat = noodle.GetComponent<Renderer>().material;
        stickMat = stick.GetComponent<Renderer>().material;

        foamBall = GameObject.Find("foamBall");
        foamBase = foamBall.GetComponent<Renderer>().materials[0];
        foamRod = foamBall.GetComponent<Renderer>().materials[1];
        foam = foamBall.GetComponent<Renderer>().materials[2];

        shrub = GameObject.Find("tree");
        bush = GameObject.Find("treePlane").GetComponent<Renderer>().material;

        stopSign = GameObject.Find("stopSign");
        nGon = GameObject.Find("NGon001");
        bh1 = GameObject.Find("blackHole");
        bh2 = GameObject.Find("blackHole2");
        bh3 = GameObject.Find("blackHole3");
        grass1 = GameObject.Find("grass1");
        grass2 = GameObject.Find("grass2");
        raised1 = GameObject.Find("raised1");
        raised2 = GameObject.Find("raised2");
        raised3 = GameObject.Find("raised3");
        raised4 = GameObject.Find("raised4");
        //remaining
        wasteBasket = GameObject.Find("wasteBasket2");
        trafficCone = GameObject.Find("trafficCone");
        trafficCone2 = GameObject.Find("trafficCone2");        
        doorRoom = GameObject.Find("doorRoom");

        //move grid down through floor
        Vector3 pos = grid.transform.position;
        pos.y -= 1f;
        grid.transform.position = pos;

        createPositionMaps();
        setCourse(10);        
       
        noodle.SetActive(false);
        stick.SetActive(false);
        foamBall.SetActive(false);
        shrub.SetActive(false);
        stopSign.SetActive(false);
        bh1.SetActive(false);
        bh2.SetActive(false);
        bh3.SetActive(false);
        grass1.SetActive(false);
        grass2.SetActive(false);
        raised1.SetActive(false);
        raised2.SetActive(false);
        raised3.SetActive(false);
        raised4.SetActive(false);
        wasteBasket.SetActive(false);
        trafficCone.SetActive(false);
        trafficCone2.SetActive(false);
        //tripod.SetActive(false);
       // tripod2.SetActive(false);
        doorRoom.SetActive(false);

        //the lines on the grid
        lines = new GameObject[17];
        lines[0] = GameObject.Find("l1");
        lines[1] = GameObject.Find("l2");
        lines[2] = GameObject.Find("l3");
        lines[3] = GameObject.Find("l4");
        lines[4] = GameObject.Find("l5");
        lines[5] = GameObject.Find("l6");
        lines[6] = GameObject.Find("l7");
        lines[7] = GameObject.Find("l8");
        lines[8] = GameObject.Find("l9");
        lines[9] = GameObject.Find("l10");
        lines[10] = GameObject.Find("l11");
        lines[11] = GameObject.Find("l12");
        lines[12] = GameObject.Find("l13");
        lines[13] = GameObject.Find("l14");
        lines[14] = GameObject.Find("l15");
        lines[15] = GameObject.Find("l16");
        lines[16] = GameObject.Find("l17");

        //hide all the lines
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].transform.localScale = new Vector3(1, 1, 0);
        }
    }


    //moves the stopSign up/down
    public void stopDown()
    {
        Vector3 curPos = nGon.transform.position;
        curPos.y -= .24f;

        LeanTween.move(nGon, curPos, 1.5f).setOnComplete(stopUp);
    }
    void stopUp()
    {
        Vector3 curPos = nGon.transform.position;
        curPos.y += .24f;

        LeanTween.move(nGon, curPos, 1.5f).setDelay(.5f);
    }


    //called from Manager.playAud25()
    public void doShuffle()
    {
        //step the first - move everything under the floor...
        //objects begin at c10
        float m = 2.5f;
        Vector3 d;

        d = c10Positions[0];
        d.y -= m;
        LeanTween.move(noodle, d, .5f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[1];
        d.y -= m;
        LeanTween.move(foamBall, d, .5f).setDelay(.1f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[2];
        d.y -= m;
        LeanTween.move(stopSign, d, .5f).setDelay(.2f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[3];
        d.y -= m;
        LeanTween.move(bh1, d, .5f).setDelay(.3f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[4];
        d.y -= m;
        LeanTween.move(bh2, d, .5f).setDelay(.4f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[5];
        d.y -= m;
        LeanTween.move(bh3, d, .5f).setDelay(.5f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[6];
        d.y -= m;
        LeanTween.move(grass1, d, .5f).setDelay(.6f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[7];
        d.y -= m;
        LeanTween.move(grass2, d, .5f).setDelay(.7f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[8];
        d.y -= m;
        LeanTween.move(raised1, d, .5f).setDelay(.8f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[9];
        d.y -= m;
        LeanTween.move(raised2, d, .5f).setDelay(.9f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[10];
        d.y -= m;
        LeanTween.move(raised3, d, .5f).setDelay(1f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[11];
        d.y -= m;
        LeanTween.move(raised4, d, .5f).setDelay(1.1f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[12];
        d.y -= m;
        LeanTween.move(wasteBasket, d, .5f).setDelay(1.2f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[13];
        d.y -= m;
        LeanTween.move(trafficCone, d, .5f).setDelay(1.3f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[14];
        d.y -= m;
        LeanTween.move(trafficCone2, d, .5f).setDelay(1.4f).setEase(LeanTweenType.easeInBack);
        d = c10Positions[15];
        d.y -= m;
        LeanTween.move(doorRoom, d, .5f).setDelay(1.5f).setEase(LeanTweenType.easeInBack).setOnComplete(shuffle2);
    }

    //all objects are now under the floor
    void shuffle2()
    {
        float m = 2.5f;
        Vector3 d;

        //step the second - move everything to new grid positions - but under the floor
        d = c5Positions[0];
        d.y -= m;
        noodle.transform.position = d;
        noodle.transform.rotation = noodleRotations[1];

        d = c5Positions[1];
        d.y -= m;
        foamBall.transform.position = d;
        
        d = c5Positions[2];
        d.y -= m;
        stopSign.transform.position = d;

        d = c5Positions[3];
        d.y -= m;
        bh1.transform.position = d;

        d = c5Positions[4];
        d.y -= m;
        bh2.transform.position = d;

        d = c5Positions[5];
        d.y -= m;
        bh3.transform.position = d;

        d = c5Positions[6];
        d.y -= m;
        grass1.transform.position = d;

        d = c5Positions[7];
        d.y -= m;
        grass2.transform.position = d;

        d = c5Positions[8];
        d.y -= m;
        raised1.transform.position = d;

        d = c5Positions[9];
        d.y -= m;
        raised2.transform.position = d;

        d = c5Positions[10];
        d.y -= m;
        raised3.transform.position = d;

        d = c5Positions[11];
        d.y -= m;
        raised4.transform.position = d;

        d = c5Positions[12];
        d.y -= m;
        wasteBasket.transform.position = d;

        d = c5Positions[13];
        d.y -= m;
        trafficCone.transform.position = d;

        d = c5Positions[14];
        d.y -= m;
        trafficCone2.transform.position = d;

        d = c5Positions[15];
        d.y -= m;
        doorRoom.transform.position = d;

        //step 3 move it all back up onto the grid in the new c5 positions
        LeanTween.move(noodle, c5Positions[0], .5f).setDelay(0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(foamBall, c5Positions[1], .5f).setDelay(.1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(stopSign, c5Positions[2], .5f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh1, c5Positions[3], .5f).setDelay(.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh2, c5Positions[4], .5f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh3, c5Positions[5], .5f).setDelay(.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(grass1, c5Positions[6], .5f).setDelay(.6f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(grass2, c5Positions[7], .5f).setDelay(.7f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised1, c5Positions[8], .5f).setDelay(.8f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised2, c5Positions[9], .5f).setDelay(.9f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised3, c5Positions[10], .5f).setDelay(1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised4, c5Positions[11], .5f).setDelay(1.1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(wasteBasket, c5Positions[12], .5f).setDelay(1.2f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(trafficCone, c5Positions[13], .5f).setDelay(1.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(trafficCone2, c5Positions[14], .5f).setDelay(1.4f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(doorRoom, c5Positions[15], .5f).setDelay(1.5f).setEase(LeanTweenType.easeOutBack);

        //show layout for a couple seconds and then show the next layout
        LeanTween.delayedCall(6f, shuffle3);
    }


    void shuffle3()
    { 
        //move everything back under the floor
        //objects in c5Positions now - moving to c11
        float m = 2.5f;
        Vector3 d;

        d = c5Positions[0];
        d.y -= m;
        LeanTween.move(noodle, d, .5f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[1];
        d.y -= m;
        LeanTween.move(foamBall, d, .5f).setDelay(.1f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[2];
        d.y -= m;
        LeanTween.move(stopSign, d, .5f).setDelay(.2f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[3];
        d.y -= m;
        LeanTween.move(bh1, d, .5f).setDelay(.3f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[4];
        d.y -= m;
        LeanTween.move(bh2, d, .5f).setDelay(.4f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[5];
        d.y -= m;
        LeanTween.move(bh3, d, .5f).setDelay(.5f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[6];
        d.y -= m;
        LeanTween.move(grass1, d, .5f).setDelay(.6f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[7];
        d.y -= m;
        LeanTween.move(grass2, d, .5f).setDelay(.7f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[8];
        d.y -= m;
        LeanTween.move(raised1, d, .5f).setDelay(.8f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[9];
        d.y -= m;
        LeanTween.move(raised2, d, .5f).setDelay(.9f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[10];
        d.y -= m;
        LeanTween.move(raised3, d, .5f).setDelay(1f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[11];
        d.y -= m;
        LeanTween.move(raised4, d, .5f).setDelay(1.1f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[12];
        d.y -= m;
        LeanTween.move(wasteBasket, d, .5f).setDelay(1.2f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[13];
        d.y -= m;
        LeanTween.move(trafficCone, d, .5f).setDelay(1.3f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[14];
        d.y -= m;
        LeanTween.move(trafficCone2, d, .5f).setDelay(1.4f).setEase(LeanTweenType.easeInBack);
        d = c5Positions[15];
        d.y -= m;
        LeanTween.move(doorRoom, d, .5f).setDelay(1.5f).setEase(LeanTweenType.easeInBack).setOnComplete(shuffle4);
    }

    void shuffle4()
    {
        float m = 2.5f;
        Vector3 d;

        //move to new c11 positions - under floor
        d = c11Positions[0];
        d.y -= m;
        noodle.transform.position = d;
        noodle.transform.rotation = noodleRotations[2];

        d = c11Positions[1];
        d.y -= m;
        foamBall.transform.position = d;

        d = c11Positions[2];
        d.y -= m;
        stopSign.transform.position = d;

        d = c11Positions[3];
        d.y -= m;
        bh1.transform.position = d;

        d = c11Positions[4];
        d.y -= m;
        bh2.transform.position = d;

        d = c11Positions[5];
        d.y -= m;
        bh3.transform.position = d;

        d = c11Positions[6];
        d.y -= m;
        grass1.transform.position = d;

        d = c11Positions[7];
        d.y -= m;
        grass2.transform.position = d;

        d = c11Positions[8];
        d.y -= m;
        raised1.transform.position = d;

        d = c11Positions[9];
        d.y -= m;
        raised2.transform.position = d;

        d = c11Positions[10];
        d.y -= m;
        raised3.transform.position = d;

        d = c11Positions[11];
        d.y -= m;
        raised4.transform.position = d;

        d = c11Positions[12];
        d.y -= m;
        wasteBasket.transform.position = d;

        d = c11Positions[13];
        d.y -= m;
        trafficCone.transform.position = d;

        d = c11Positions[14];
        d.y -= m;
        trafficCone2.transform.position = d;

        d = c11Positions[15];
        d.y -= m;
        doorRoom.transform.position = d;

        //move it all back up onto the grid in the new c11 positions
        LeanTween.move(noodle, c11Positions[0], .5f).setDelay(0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(foamBall, c11Positions[1], .5f).setDelay(.1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(stopSign, c11Positions[2], .5f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh1, c11Positions[3], .5f).setDelay(.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh2, c11Positions[4], .5f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh3, c11Positions[5], .5f).setDelay(.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(grass1, c11Positions[6], .5f).setDelay(.6f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(grass2, c11Positions[7], .5f).setDelay(.7f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised1, c11Positions[8], .5f).setDelay(.8f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised2, c11Positions[9], .5f).setDelay(.9f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised3, c11Positions[10], .5f).setDelay(1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised4, c11Positions[11], .5f).setDelay(1.1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(wasteBasket, c11Positions[12], .5f).setDelay(1.2f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(trafficCone, c11Positions[13], .5f).setDelay(1.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(trafficCone2, c11Positions[14], .5f).setDelay(1.4f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(doorRoom, c11Positions[15], .5f).setDelay(1.5f).setEase(LeanTweenType.easeOutBack);

        //show layout for a couple seconds and then show the next layout
        LeanTween.delayedCall(6f, shuffle5);
    }


    void shuffle5()
    {
        //move everything down...currently in c11
        float m = 2.5f;
        Vector3 d;

        d = c11Positions[0];
        d.y -= m;
        LeanTween.move(noodle, d, .5f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[1];
        d.y -= m;
        LeanTween.move(foamBall, d, .5f).setDelay(.1f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[2];
        d.y -= m;
        LeanTween.move(stopSign, d, .5f).setDelay(.2f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[3];
        d.y -= m;
        LeanTween.move(bh1, d, .5f).setDelay(.3f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[4];
        d.y -= m;
        LeanTween.move(bh2, d, .5f).setDelay(.4f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[5];
        d.y -= m;
        LeanTween.move(bh3, d, .5f).setDelay(.5f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[6];
        d.y -= m;
        LeanTween.move(grass1, d, .5f).setDelay(.6f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[7];
        d.y -= m;
        LeanTween.move(grass2, d, .5f).setDelay(.7f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[8];
        d.y -= m;
        LeanTween.move(raised1, d, .5f).setDelay(.8f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[9];
        d.y -= m;
        LeanTween.move(raised2, d, .5f).setDelay(.9f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[10];
        d.y -= m;
        LeanTween.move(raised3, d, .5f).setDelay(1f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[11];
        d.y -= m;
        LeanTween.move(raised4, d, .5f).setDelay(1.1f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[12];
        d.y -= m;
        LeanTween.move(wasteBasket, d, .5f).setDelay(1.2f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[13];
        d.y -= m;
        LeanTween.move(trafficCone, d, .5f).setDelay(1.3f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[14];
        d.y -= m;
        LeanTween.move(trafficCone2, d, .5f).setDelay(1.4f).setEase(LeanTweenType.easeInBack);
        d = c11Positions[15];
        d.y -= m;
        LeanTween.move(doorRoom, d, .5f).setDelay(1.5f).setEase(LeanTweenType.easeInBack).setOnComplete(shuffle6);

    }

    void shuffle6()
    {
        float m = 2.5f;
        Vector3 d;

        //finally move everything back to original c10 positions
        d = c10Positions[0];
        d.y -= m;
        noodle.transform.position = d;
        noodle.transform.rotation = noodleRotations[0];

        d = c10Positions[1];
        d.y -= m;
        foamBall.transform.position = d;

        d = c10Positions[2];
        d.y -= m;
        stopSign.transform.position = d;

        d = c10Positions[3];
        d.y -= m;
        bh1.transform.position = d;

        d = c10Positions[4];
        d.y -= m;
        bh2.transform.position = d;

        d = c10Positions[5];
        d.y -= m;
        bh3.transform.position = d;

        d = c10Positions[6];
        d.y -= m;
        grass1.transform.position = d;

        d = c10Positions[7];
        d.y -= m;
        grass2.transform.position = d;

        d = c10Positions[8];
        d.y -= m;
        raised1.transform.position = d;

        d = c10Positions[9];
        d.y -= m;
        raised2.transform.position = d;

        d = c10Positions[10];
        d.y -= m;
        raised3.transform.position = d;

        d = c10Positions[11];
        d.y -= m;
        raised4.transform.position = d;

        d = c10Positions[12];
        d.y -= m;
        wasteBasket.transform.position = d;

        d = c10Positions[13];
        d.y -= m;
        trafficCone.transform.position = d;

        d = c10Positions[14];
        d.y -= m;
        trafficCone2.transform.position = d;

        d = c10Positions[15];
        d.y -= m;
        doorRoom.transform.position = d;

        //move it all back up onto the grid in the new c10 positions
        LeanTween.move(noodle, c10Positions[0], .5f).setDelay(0f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(foamBall, c10Positions[1], .5f).setDelay(.1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(stopSign, c10Positions[2], .5f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh1, c10Positions[3], .5f).setDelay(.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh2, c10Positions[4], .5f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(bh3, c10Positions[5], .5f).setDelay(.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(grass1, c10Positions[6], .5f).setDelay(.6f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(grass2, c10Positions[7], .5f).setDelay(.7f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised1, c10Positions[8], .5f).setDelay(.8f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised2, c10Positions[9], .5f).setDelay(.9f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised3, c10Positions[10], .5f).setDelay(1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(raised4, c10Positions[11], .5f).setDelay(1.1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(wasteBasket, c10Positions[12], .5f).setDelay(1.2f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(trafficCone, c10Positions[13], .5f).setDelay(1.3f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(trafficCone2, c10Positions[14], .5f).setDelay(1.4f).setEase(LeanTweenType.easeOutBack);
        LeanTween.move(doorRoom, c10Positions[15], .5f).setDelay(1.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(doCB);

        //AND DONE!
    }
    void doCB()
    {
        mainManager.bringBackArrows();
    }


    public void setCourse(int courseNum)
    {
        List<Vector3> theCourse;
        Quaternion rot;

        switch (courseNum)
        {
            case 10:
                theCourse = c10Positions;
                rot = noodleRotations[0];
                break;
            case 5:
                theCourse = c5Positions;
                rot = noodleRotations[1];
                break;
            case 11:
                theCourse = c11Positions;
                rot = noodleRotations[2];
                break;
            default:
                theCourse = c10Positions;
                rot = noodleRotations[0];
                break;
        }

        noodle.transform.position = theCourse[0];        
        foamBall.transform.position = theCourse[1];
        stopSign.transform.position = theCourse[2];
        bh1.transform.position = theCourse[3];
        bh2.transform.position = theCourse[4];
        bh3.transform.position = theCourse[5];
        grass1.transform.position = theCourse[6];
        grass2.transform.position = theCourse[7];
        raised1.transform.position = theCourse[8];
        raised2.transform.position = theCourse[9];
        raised3.transform.position = theCourse[10];
        raised4.transform.position = theCourse[11];
        wasteBasket.transform.position = theCourse[12];
        trafficCone.transform.position = theCourse[13];
        trafficCone2.transform.position = theCourse[14];
        doorRoom.transform.position = theCourse[15];

        noodle.transform.rotation = rot;
    }

    //Course layout positions - these are the on grid positions
    void createPositionMaps()
    {
        noodleRotations = new List<Quaternion>();
       
        //Course 10
        c10Positions = new List<Vector3>();
        c10Positions.Add(new Vector3(3.85f, -1.39f, 2.259f));//noodle - rotation -177.617, -363.72, 4.323
        c10Positions.Add(new Vector3(2.692f, -1.425f, 3.676f));//foamBall
        c10Positions.Add(new Vector3(5.411f, -1.392f, 1.831f));//stopSign
        c10Positions.Add(new Vector3(4.54f, -1.429f, 3.183f));//blackHole
        c10Positions.Add(new Vector3(3.163f, -1.429f, 2.273f));//blackHole2
        c10Positions.Add(new Vector3(1.789f, -1.429f, 3.643f));//blackHole3
        c10Positions.Add(new Vector3(5.45f, -1.429f, 3.641f));//grass1
        c10Positions.Add(new Vector3(2.245f, -1.429f, 1.816f));//grass2
        c10Positions.Add(new Vector3(4.989f, -1.429f, 2.729f));//raised1
        c10Positions.Add(new Vector3(4.533f, -1.431f, 2.27f));//raised2
        c10Positions.Add(new Vector3(2.706f, -1.429f, 3.182f));//raised3
        c10Positions.Add(new Vector3(3.618f, -1.431f, 3.642f));//raised4
        c10Positions.Add(new Vector3(1.33f, -1.44f, 1.814f));//wastebasket
        c10Positions.Add(new Vector3(1.315f, -1.211f, 2.73f));//trafficCone
        c10Positions.Add(new Vector3(3.596f, -1.211f, 2.73f));//trafficCone2
        c10Positions.Add(new Vector3(1.1120f, -1.46f, 4.07f));//doorRoom

        noodleRotations.Add(new Quaternion(1, 0, 0, 0));
        


        //Course 5
        c5Positions = new List<Vector3>();
        c5Positions.Add(new Vector3(3.85f, -1.39f, 3.214f));//noodle - rotation -179.406, -365.51, 3.141998
        c5Positions.Add(new Vector3(5.453f, -1.425f, 2.289f));//foamBall
        c5Positions.Add(new Vector3(4.032f, -1.392f, 2.747f));//stopSign
        c5Positions.Add(new Vector3(1.335f, -1.429f, 1.812f));//blackHole
        c5Positions.Add(new Vector3(3.621f, -1.429f, 3.185f));//blackHole2
        c5Positions.Add(new Vector3(4.994f, -1.429f, 2.272f));//blackHole3
        c5Positions.Add(new Vector3(4.992f, -1.429f, 3.187f));//grass1
        c5Positions.Add(new Vector3(2.703f, -1.429f, 2.27f));//grass2
        c5Positions.Add(new Vector3(1.791f, -1.429f, 2.729f));//raised1
        c5Positions.Add(new Vector3(3.61f, -1.431f, 1.819f));//raised2
        c5Positions.Add(new Vector3(3.16f, -1.429f, 2.73f));//raised3
        c5Positions.Add(new Vector3(2.244f, -1.431f, 3.642f));//raised4
        c5Positions.Add(new Vector3(4.989f, -1.44f, 1.814f));//wastebasket
        c5Positions.Add(new Vector3(2.688f, -1.213f, 3.205f));//trafficCone
        c5Positions.Add(new Vector3(3.595f, -1.211f, 2.73f));//trafficCone2
        c5Positions.Add(new Vector3(4.324f, -1.46f, 1.37f));//doorRoom

        noodleRotations.Add(new Quaternion(0, 0, 0, -1));


        //Course 11
        c11Positions = new List<Vector3>();
        c11Positions.Add(new Vector3(2.013f, -1.39f, 1.786f));//noodle - rotation -178.895, -537.399, 179.238 - same noodle pos as C10
        c11Positions.Add(new Vector3(5.44f, -1.425f, 2.286f));//foamBall
        c11Positions.Add(new Vector3(4.036f, -1.392f, 2.746f));//stopSign
        c11Positions.Add(new Vector3(1.789f, -1.429f, 3.641f));//blackHole
        c11Positions.Add(new Vector3(1.79f, -1.429f, 1.816f));//blackHole2
        c11Positions.Add(new Vector3(4.536f, -1.429f, 3.187f));//blackHole3
        c11Positions.Add(new Vector3(3.6189f, -1.429f, 1.816f));//grass1
        c11Positions.Add(new Vector3(5.448f, -1.429f, 3.638f));//grass2
        c11Positions.Add(new Vector3(3.164f, -1.429f, 2.269f));//raised1
        c11Positions.Add(new Vector3(3.166f, -1.431f, 3.186f));//raised2
        c11Positions.Add(new Vector3(4.99f, -1.429f, 2.73f));//raised3
        c11Positions.Add(new Vector3(4.535f, -1.431f, 2.27f));//raised4
        c11Positions.Add(new Vector3(1.33f, -1.44f, 3.63f));//wastebasket
        c11Positions.Add(new Vector3(1.318f, -1.211f, 2.736f));//trafficCone
        c11Positions.Add(new Vector3(3.599f, -1.211f, 2.736f));//trafficCone2
        c11Positions.Add(new Vector3(1.162f, -1.46f, 1.396f));//doorRoom - rotation: 0,180,0

        noodleRotations.Add(new Quaternion(0, 0, 0, 1));
    }

    //called from Manager when user chose skip to lux levels on start screen
    public void showItAll()
    {
        showGrid(true);//don't draw the grid lines
        noodle.SetActive(true);
       // stick.SetActive(true);
        foamBall.SetActive(true);
        //shrub.SetActive(true);
        stopSign.SetActive(true);
        bh1.SetActive(true);
        bh2.SetActive(true);
        bh3.SetActive(true);
        grass1.SetActive(true);
        grass2.SetActive(true);
        raised1.SetActive(true);
        raised2.SetActive(true);
        raised3.SetActive(true);
        raised4.SetActive(true);
        wasteBasket.SetActive(true);
        trafficCone.SetActive(true);
        trafficCone2.SetActive(true);
        doorRoom.SetActive(true);
    }




    public void showGrid(bool fast = false)
    {
        Vector3 pos = grid.transform.position;
        pos.y += 1f;
        if (fast)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                LeanTween.scale(lines[i], new Vector3(1, 1, 1), 0f);
            }
            LeanTween.move(grid, pos, 1f).setEase(LeanTweenType.easeOutBack);
        }
        else
        {
            LeanTween.move(grid, pos, 1f).setEase(LeanTweenType.easeOutBack).setOnComplete(drawGridLines);
        }        
    }

    void drawGridLines()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            LeanTween.scale(lines[i], new Vector3(1, 1, 1), 2f).setDelay(i * .5f);
        }
    }


    public void showNoodle()
    {
        objectDestination = noodle.transform.position;//original grid position
        Vector3 floatPosition = new Vector3(objectDestination.x, objectDestination.y - 1f, objectDestination.z);
        noodle.transform.position = floatPosition;
        noodle.SetActive(true);
       // noodle.GetComponent<Animator>().SetTrigger("noodleMotion");
        LeanTween.move(noodle, objectDestination, 2f).setEase(LeanTweenType.easeOutBack).setOnComplete(waitOne);
    }
    void waitOne()
    {
        LeanTween.delayedCall(1.5f, showStick);
    }
    private void showStick()
    {
        LeanTween.value(grid, setNoodleVal, 1f, 0f, .5f).setOnComplete(fadeInStick);
    }
    void setNoodleVal(float val)
    {
        noodleMat.SetColor("_Color", new Color(.10588f, .45098f, .8588f, val));        
    }
    void fadeInStick()
    {
        noodle.SetActive(false);
        stick.SetActive(true);
        LeanTween.value(grid, setStickVal, 0f, 1f, .5f);
        LeanTween.delayedCall(1.5f, hideStick);
    }
    void setStickVal(float val)
    {
        stickMat.SetColor("_Color", new Color(.2706f, .22745f, .09412f, val));
    }
    private void hideStick()
    {
        LeanTween.value(grid, setStickVal, 1f, 0f, .5f).setOnComplete(showNoodle2);
    }
    private void showNoodle2()
    {
        stick.SetActive(false);
        noodle.SetActive(true);
        LeanTween.value(grid, setNoodleVal, 0f, 1f, .5f);
    }


    public void showFoamCircle()
    {
        objectDestination = foamBall.transform.position;//original grid position
        Vector3 floatPosition = new Vector3(objectDestination.x, objectDestination.y - 1.25f, objectDestination.z);
        foamBall.transform.position = floatPosition;
        foamBall.SetActive(true);
        LeanTween.move(foamBall, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.delayedCall(8f, fadeOutFoam);
    }
    private void fadeOutFoam()
    {
        LeanTween.value(grid, setFoamVal, 1f, 0f, .5f).setOnComplete(fadeInShrub);
    }
    void setFoamVal(float val)
    {
        foam.SetColor("_Color", new Color(.8196f, .8196f, .8196f, val));
        foamRod.SetColor("_Color", new Color(.0117f, .0117f, .0117f, val));
        foamBase.SetColor("_Color", new Color(.4509f, .4509f, .4509f, val));
    }
    void fadeInShrub()
    {
        foamBall.SetActive(false);
        shrub.SetActive(true);
        LeanTween.value(grid, setShrubVal, 0f, 1f, .5f);
        LeanTween.delayedCall(2f, fadeOutShrub);
    }
    void setShrubVal(float val)
    {
        bush.SetColor("_Color", new Color(1f, 1f, 1f, val));
    }
    void fadeOutShrub()
    {
        LeanTween.value(grid, setShrubVal, 1f, 0f, .5f).setOnComplete(showFoam2);
    }
    void showFoam2()
    {
        foamBall.SetActive(true);
        shrub.SetActive(false);
        LeanTween.value(grid, setFoamVal, 0f, 1f, .5f);
    }
    public void showStopSign()
    {
        objectDestination = stopSign.transform.position;//original grid position
        Vector3 floatPosition = new Vector3(objectDestination.x, objectDestination.y - 1.25f, objectDestination.z);
        stopSign.transform.position = floatPosition;
        stopSign.SetActive(true);
        LeanTween.move(stopSign, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);       
    }


    public void showBlackHoles()
    {
        Vector3 floatPosition;

        objectDestination = bh1.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        bh1.transform.position = floatPosition;
        bh1.SetActive(true);
        LeanTween.move(bh1, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);

        objectDestination = bh2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        bh2.transform.position = floatPosition;
        bh2.SetActive(true);
        LeanTween.move(bh2, objectDestination, 1f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);

        objectDestination = bh3.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        bh3.transform.position = floatPosition;
        bh3.SetActive(true);
        LeanTween.move(bh3, objectDestination, 1f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);
    }


    public void showGrass()
    {
        Vector3 floatPosition;

        objectDestination = grass1.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        grass1.transform.position = floatPosition;
        grass1.SetActive(true);
        LeanTween.move(grass1, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);

        objectDestination = grass2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        grass2.transform.position = floatPosition;
        grass2.SetActive(true);
        LeanTween.move(grass2, objectDestination, 1f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);
    }


    public void showRaisedBlocks()
    {
        Vector3 floatPosition;

        objectDestination = raised1.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised1.transform.position = floatPosition;
        raised1.SetActive(true);
        LeanTween.move(raised1, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);       

        objectDestination = raised3.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised3.transform.position = floatPosition;
        raised3.SetActive(true);
        LeanTween.move(raised3, objectDestination, 1f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);       
    }



    public void showRemaining()
    {
        Vector3 floatPosition;

        objectDestination = wasteBasket.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        wasteBasket.transform.position = floatPosition;
        wasteBasket.SetActive(true);
        LeanTween.move(wasteBasket, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);

        objectDestination = trafficCone.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        trafficCone.transform.position = floatPosition;
        trafficCone.SetActive(true);
        LeanTween.move(trafficCone, objectDestination, 1f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);

        objectDestination = trafficCone2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        trafficCone2.transform.position = floatPosition;
        trafficCone2.SetActive(true);
        LeanTween.move(trafficCone2, objectDestination, 1f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);

        //taller raised blocks
        objectDestination = raised2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised2.transform.position = floatPosition;
        raised2.SetActive(true);
        LeanTween.move(raised2, objectDestination, 1f).setDelay(.6f).setEase(LeanTweenType.easeOutBack);

        objectDestination = raised4.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised4.transform.position = floatPosition;
        raised4.SetActive(true);
        LeanTween.move(raised4, objectDestination, 1f).setDelay(.8f).setEase(LeanTweenType.easeOutBack);
        /*
        objectDestination = tripod.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        tripod.transform.position = floatPosition;
        tripod.SetActive(true);
        LeanTween.move(tripod, objectDestination, 1f).setDelay(.6f).setEase(LeanTweenType.easeOutBack);

        objectDestination = tripod2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        tripod2.transform.position = floatPosition;
        tripod2.SetActive(true);
        LeanTween.move(tripod2, objectDestination, 1f).setDelay(.8f).setEase(LeanTweenType.easeOutBack);
        */
        objectDestination = doorRoom.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - 2.5f, objectDestination.z);
        doorRoom.transform.position = floatPosition;
        doorRoom.SetActive(true);
        LeanTween.move(doorRoom, objectDestination, 1f).setDelay(1f).setEase(LeanTweenType.easeOutBack);
    }


}
