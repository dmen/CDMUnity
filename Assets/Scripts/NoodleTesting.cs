using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleTesting : MonoBehaviour
{
    GameObject grid;
    GameObject noodle;
    GameObject stick;
    Material noodleMat;
    Material stickMat;
    Vector3 objectDestination;
    ParticleSystem stickSystem;
    ParticleSystem noodleSystem;
    ParticleSystem sparks;


    // Use this for initialization
    void Start()
    {
        grid = GameObject.Find("gridLines");

        noodle = GameObject.Find("noodle");
        stick = GameObject.Find("stick");
        noodleMat = noodle.GetComponent<Renderer>().material;
        stickMat = stick.GetComponent<Renderer>().material;

        noodleSystem = GameObject.Find("particleNoodle").GetComponent<ParticleSystem>();
        stickSystem = GameObject.Find("particleStick").GetComponent<ParticleSystem>();
        sparks = GameObject.Find("sparks").GetComponent<ParticleSystem>();

        noodle.SetActive(false);
        stick.SetActive(false);

        noodleSystem.Stop();
        stickSystem.Stop();
        sparks.Stop();

        showNoodle();
    }

   
    public void showNoodle()
    {
        objectDestination = noodle.transform.position;//original grid position
        Vector3 floatPosition = new Vector3(objectDestination.x, objectDestination.y - 1f, objectDestination.z);//under the grid
        noodle.transform.position = floatPosition;
        noodle.SetActive(true);

        LeanTween.move(noodle, objectDestination, 1f).setEase(LeanTweenType.easeOutBack);
        LeanTween.delayedCall(2f, startBlueParticles);
        LeanTween.delayedCall(3f, startBrownParticles);

        LeanTween.delayedCall(3f, hideTheNoodle);
        LeanTween.delayedCall(4f, showTheStick);
    }


    void startBlueParticles()
    {
        noodleSystem.Play();
    }


    void startBrownParticles()
    {
        stickSystem.Play();
    }


    void hideTheNoodle()
    {
        noodle.SetActive(false);
        sparks.Play();
    }


    void showTheStick()
    {
        stick.SetActive(true);
    }
}
