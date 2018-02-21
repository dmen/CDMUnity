using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotate : MonoBehaviour
{
    Transform player;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }


    public void getActive()
    {
        GameObject mommy = new GameObject();
        mommy.transform.position = player.transform.position;

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
            if (go.activeInHierarchy)
            {
                go.transform.parent = mommy.transform;
            }


    }    

}
