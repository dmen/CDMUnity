using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFollower : MonoBehaviour
{
    public EditorPathScript pathToFollow;
    public Manager managerScript;
    public float speed;

    //how close to get to the path nodes
    public float reachDistance = 1.0f;   

    //start of path
    private int currentWayPointID = 0;

    private bool isPathPaused = false;

	
	void Update ()
    {
        if (!isPathPaused)
        {
            float distance = Vector3.Distance(pathToFollow.path_objs[currentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);

            if (distance <= reachDistance)
            {
                currentWayPointID++;
                if(currentWayPointID > 1)
                {
                    //tell the manager what node was reached - manager will call pausePath()
                    //to stop the animation
                    //managerScript.nodeReached(currentWayPointID);
                }
               
            }
        }
       

        /*
        if(currentWayPointID >= pathToFollow.path_objs.Count)
        {
            currentWayPointID = 0;
        }
        */
	}


    void moveToNextNode()
    {
        //LeanTween.move(this, 1f, 1f).setEase(LeanTweenType.easeInQuad);
    }


    public void pausePath()
    {
        isPathPaused = true;
    }


    public void playPath()
    {
        isPathPaused = false;
    }
}
