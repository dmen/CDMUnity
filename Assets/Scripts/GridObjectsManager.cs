using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectsManager : MonoBehaviour
{
    GameObject step1;
    GameObject step2;
    GameObject step3;
    GameObject step4;
    GameObject step5;
    GameObject step6;
    GameObject step7;

    GameObject grid;

    GameObject noodle;
    GameObject stick;

    GameObject foamBall;
    GameObject shrub;

    GameObject stopSign;

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
    GameObject tripod;
    GameObject tripod2;
    GameObject doorRoom;

    Vector3 objectDestination;


    void Start()
    {
        step1 = GameObject.Find("step1");
        step2 = GameObject.Find("step2");
        step3 = GameObject.Find("step3");
        step4 = GameObject.Find("step4");
        step5 = GameObject.Find("step5");
        step6 = GameObject.Find("step6");
        step7 = GameObject.Find("step7");

        grid = GameObject.Find("grid");
        noodle = GameObject.Find("noodle");
        stick = GameObject.Find("stick");
        foamBall = GameObject.Find("foamBall");
        shrub = GameObject.Find("theBush");
        stopSign = GameObject.Find("stopSign");
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
        wasteBasket = GameObject.Find("wasteBasket");
        trafficCone = GameObject.Find("trafficCone");
        trafficCone2 = GameObject.Find("trafficCone2");
        tripod = GameObject.Find("tripod");
        tripod2 = GameObject.Find("tripod2");
        doorRoom = GameObject.Find("doorRoom");

        //move grid down through floor
        Vector3 pos = grid.transform.position;
        pos.y -= .5f;
        grid.transform.position = pos;

        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        step4.SetActive(false);
        step5.SetActive(false);
        step6.SetActive(false);
        step7.SetActive(false);
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
    }


    public void showFootSteps()
    {
        Vector3 floatPosition;
        float stepDelay = .3f;

        objectDestination = step1.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step1.transform.position = floatPosition;
        step1.SetActive(true);
        LeanTween.move(step1, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);

        objectDestination = step2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step2.transform.position = floatPosition;
        step2.SetActive(true);
        LeanTween.move(step2, objectDestination, 1f).setDelay(stepDelay).setEase(LeanTweenType.easeOutBack);

        objectDestination = step3.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step3.transform.position = floatPosition;
        step3.SetActive(true);
        LeanTween.move(step3, objectDestination, 1f).setDelay(stepDelay * 2).setEase(LeanTweenType.easeOutBack);

        objectDestination = step4.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step4.transform.position = floatPosition;
        step4.SetActive(true);
        LeanTween.move(step4, objectDestination, 1f).setDelay(stepDelay * 3).setEase(LeanTweenType.easeOutBack);

        objectDestination = step5.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step5.transform.position = floatPosition;
        step5.SetActive(true);
        LeanTween.move(step5, objectDestination, 1f).setDelay(stepDelay * 4).setEase(LeanTweenType.easeOutBack);

        objectDestination = step6.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step6.transform.position = floatPosition;
        step6.SetActive(true);
        LeanTween.move(step6, objectDestination, 1f).setDelay(stepDelay * 5).setEase(LeanTweenType.easeOutBack);

        objectDestination = step7.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .25f, objectDestination.z);
        step7.transform.position = floatPosition;
        step7.SetActive(true);
        LeanTween.move(step7, objectDestination, 1f).setDelay(stepDelay * 6).setEase(LeanTweenType.easeOutBack);
    }


    //called from Manager when user chose skip to lux levels on start screen
    public void showItAll()
    {
        showGrid();
        step1.SetActive(true);
        step2.SetActive(true);
        step3.SetActive(true);
        step4.SetActive(true);
        step5.SetActive(true);
        step6.SetActive(true);
        step7.SetActive(true);
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

    public void showGrid()
    {
        Vector3 pos = grid.transform.position;
        pos.y += .5f;
        LeanTween.move(grid, pos, .5f).setEase(LeanTweenType.easeOutBack);
    }


    public void showNoodle()
    {
        objectDestination = noodle.transform.position;//original grid position
        Vector3 floatPosition = new Vector3(objectDestination.x, objectDestination.y - 1f, objectDestination.z);
        noodle.transform.position = floatPosition;
        noodle.SetActive(true);
       // noodle.GetComponent<Animator>().SetTrigger("noodleMotion");
        LeanTween.move(noodle, objectDestination, 2f).setEase(LeanTweenType.easeOutBack).setOnComplete(showStick);
    }
    private void showStick()
    {
        stick.SetActive(true);
        noodle.SetActive(false);
        LeanTween.delayedCall(2f, hideStick);
    }
    private void hideStick()
    {
        stick.SetActive(false);
        noodle.SetActive(true);
    }


    public void showFoamCircle()
    {
        objectDestination = foamBall.transform.position;//original grid position
        Vector3 floatPosition = new Vector3(objectDestination.x, objectDestination.y - 1.25f, objectDestination.z);
        foamBall.transform.position = floatPosition;
        foamBall.SetActive(true);
        LeanTween.move(foamBall, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.delayedCall(7f, showShrub);
    }
    private void showShrub()
    {
        shrub.SetActive(true);
        foamBall.SetActive(false);
        LeanTween.delayedCall(3f, hideShrub);
    }
    private void hideShrub()
    {
        shrub.SetActive(false);
        foamBall.SetActive(true);
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

        objectDestination = raised2.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised2.transform.position = floatPosition;
        raised2.SetActive(true);
        LeanTween.move(raised2, objectDestination, 1f).setDelay(.2f).setEase(LeanTweenType.easeOutBack);

        objectDestination = raised3.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised3.transform.position = floatPosition;
        raised3.SetActive(true);
        LeanTween.move(raised3, objectDestination, 1f).setDelay(.4f).setEase(LeanTweenType.easeOutBack);

        objectDestination = raised4.transform.position;//original grid position
        floatPosition = new Vector3(objectDestination.x, objectDestination.y - .5f, objectDestination.z);
        raised4.transform.position = floatPosition;
        raised4.SetActive(true);
        LeanTween.move(raised4, objectDestination, 1f).setDelay(.6f).setEase(LeanTweenType.easeOutBack);
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
        LeanTween.move(doorRoom, objectDestination, 1f).setDelay(.8f).setEase(LeanTweenType.easeOutBack);
    }


}
