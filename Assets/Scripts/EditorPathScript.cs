using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attached to path holders in the editor
 * Draws lines and spheres at each node in the path
 */


public class EditorPathScript : MonoBehaviour
{
    public float nodeSize = 0.25f;
    public Color rayColor = Color.white;
    //each path has its own speed
    public float pathSpeed = 15.0f;   

    public List<Transform> path_objs = new List<Transform>();

    //initial pre-filtered transforms
    private Transform[] theArray;



    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;

        //get list of all transforms in the holder - includes the holder itself
        theArray = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach(Transform path_obj in theArray)
        {
            if(path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        }

        for(int i = 0; i < path_objs.Count; i++)
        {
            Vector3 position = path_objs[i].position;
            if(i > 0)
            {
                Vector3 previous = path_objs[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, nodeSize);
            }
        }

    }
}
