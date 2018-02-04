using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBetween : MonoBehaviour
{
    Transform ePos;

    private void Start()
    {
        ePos = GameObject.Find("buttonStart").transform;
    }
	
	void Update ()
    {
        Vector3 playerAngle = new Vector3(ePos.forward.x, 0.0f, transform.forward.z);
        Vector3 cameraAngle = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z);

        float horizDiffAngle = Vector3.Angle(playerAngle, cameraAngle);

        Debug.Log(horizDiffAngle);
    }

   
}
