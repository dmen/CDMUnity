using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

public class CourseSetter : MonoBehaviour
{  

    // add menu item
    [MenuItem("MyMenu/Course 5")]
    

    static void Course5()
    {        
        GameObject.Find("noodle").transform.position = new Vector3(3.85f, -1.39f, 3.214f);
        GameObject.Find("foamBall").transform.position = new Vector3(5.453f, -1.425f, 2.289f);//foamBall
        GameObject.Find("stopSign").transform.position = new Vector3(4.032f, -1.392f, 2.747f);//stopSign
        GameObject.Find("blackHole").transform.position = new Vector3(1.335f, -1.429f, 1.812f);//blackHole
        GameObject.Find("blackHole2").transform.position = new Vector3(3.621f, -1.429f, 3.185f);//blackHole2
        GameObject.Find("blackHole3").transform.position = new Vector3(4.994f, -1.429f, 2.272f);//blackHole3
        GameObject.Find("grass1").transform.position = new Vector3(4.992f, -1.421f, 3.187f);//grass1
        GameObject.Find("grass2").transform.position = new Vector3(2.703f, -1.421f, 2.27f);//grass2
        GameObject.Find("raised1").transform.position = new Vector3(1.791f, -1.429f, 2.729f);//raised1
        GameObject.Find("raised2").transform.position = new Vector3(3.61f, -1.431f, 1.819f);//raised2
        GameObject.Find("raised3").transform.position = new Vector3(3.16f, -1.429f, 2.73f);//raised3
        GameObject.Find("raised4").transform.position = new Vector3(2.244f, -1.431f, 3.642f);//raised4
        GameObject.Find("wasteBasket").transform.position = new Vector3(4.989f, -0.931f, 1.808f);//wastebasket
        GameObject.Find("trafficCone").transform.position = new Vector3(2.688f, -1.213f, 3.205f);//trafficCone
        GameObject.Find("trafficCone2").transform.position = new Vector3(3.595f, -1.211f, 2.73f);//trafficCone2
        GameObject.Find("doorRoom").transform.position = new Vector3(4.324f, -1.46f, 1.37f);//doorRoom

        GameObject.Find("noodle").transform.rotation = new Quaternion(0, 0, 0, -1);        
    }


    [MenuItem("MyMenu/Course 10")]
    static void Course10()
    {
        GameObject.Find("noodle").transform.position = new Vector3(3.85f, -1.39f, 2.259f);
        GameObject.Find("foamBall").transform.position = new Vector3(2.692f, -1.425f, 3.676f);//foamBall
        GameObject.Find("stopSign").transform.position = new Vector3(5.411f, -1.392f, 1.831f);//stopSign
        GameObject.Find("blackHole").transform.position = new Vector3(4.54f, -1.429f, 3.183f);//blackHole
        GameObject.Find("blackHole2").transform.position = new Vector3(3.163f, -1.429f, 2.277f);//blackHole2
        GameObject.Find("blackHole3").transform.position = new Vector3(1.789f, -1.429f, 3.643f);//blackHole3
        GameObject.Find("grass1").transform.position = new Vector3(5.45f, -1.421f, 3.641f);//grass1
        GameObject.Find("grass2").transform.position = new Vector3(2.245f, -1.421f, 1.816f);//grass2
        GameObject.Find("raised1").transform.position = new Vector3(4.989f, -1.429f, 2.729f);//raised1
        GameObject.Find("raised2").transform.position = new Vector3(4.533f, -1.431f, 2.27f);//raised2
        GameObject.Find("raised3").transform.position = new Vector3(2.706f, -1.429f, 3.182f);//raised3
        GameObject.Find("raised4").transform.position = new Vector3(3.618f, -1.431f, 3.642f);//raised4
        GameObject.Find("wasteBasket").transform.position = new Vector3(1.328f, -0.931f, 1.808f);//wastebasket
        GameObject.Find("trafficCone").transform.position = new Vector3(1.3158f, -1.211f, 2.730f);//trafficCone
        GameObject.Find("trafficCone2").transform.position = new Vector3(3.596f, -1.211f, 2.730f);//trafficCone2
        GameObject.Find("doorRoom").transform.position = new Vector3(1.1120f, -1.46f, 4.07f);//doorRoom

        GameObject.Find("noodle").transform.rotation = new Quaternion(1, 0, 0, 0);
    }


    [MenuItem("MyMenu/Course 11")]
    static void Course11()
    {
        GameObject.Find("noodle").transform.position = new Vector3(2.013f, -1.39f, 1.786f);
        GameObject.Find("foamBall").transform.position = new Vector3(5.44f, -1.425f, 2.286f);//foamBall
        GameObject.Find("stopSign").transform.position = new Vector3(4.036f, -1.392f, 2.746f);//stopSign
        GameObject.Find("blackHole").transform.position = new Vector3(1.789f, -1.429f, 3.641f);//blackHole
        GameObject.Find("blackHole2").transform.position = new Vector3(1.79f, -1.429f, 1.816f);//blackHole2
        GameObject.Find("blackHole3").transform.position = new Vector3(4.536f, -1.429f, 3.187f);//blackHole3
        GameObject.Find("grass1").transform.position = new Vector3(3.6189f, -1.421f, 1.816f);//grass1
        GameObject.Find("grass2").transform.position = new Vector3(5.448f, -1.421f, 3.638f);//grass2
        GameObject.Find("raised1").transform.position = new Vector3(3.164f, -1.429f, 2.269f);//raised1
        GameObject.Find("raised2").transform.position = new Vector3(3.166f, -1.431f, 3.186f);//raised2
        GameObject.Find("raised3").transform.position = new Vector3(4.99f, -1.429f, 2.73f);//raised3
        GameObject.Find("raised4").transform.position = new Vector3(4.535f, -1.431f, 2.27f);//raised4
        GameObject.Find("wasteBasket").transform.position = new Vector3(1.33f, -0.931f, 3.648f);//wastebasket
        GameObject.Find("trafficCone").transform.position = new Vector3(1.318f, -1.211f, 2.736f);//trafficCone
        GameObject.Find("trafficCone2").transform.position = new Vector3(3.599f, -1.211f, 2.736f);//trafficCone2
        GameObject.Find("doorRoom").transform.position = new Vector3(1.162f, -1.46f, 1.396f);//doorRoom

        GameObject.Find("noodle").transform.rotation = new Quaternion(0, 0, 0, 1);
    }

}

