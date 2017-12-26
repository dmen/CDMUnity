using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attached to the parent GameObject of the path nodes
 * just draws a sphere and a line between each node * 
 */


public class EditorPath : MonoBehaviour
{
    //pathNodes is accessed by Manager
    public List<GameObject> pathNodes;

    
    private void Awake()
    {
        populateNodes();
    }


    /*
     * Creates the sorted by hierarchy pathNodes list
     */
    void populateNodes()
    { 
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("pathNode");
        pathNodes = new List<GameObject>();        
        
        for(int j = 0; j < nodes.Length; j++)
        {
            GameObject n = nodes[j];

            bool didInsert = false;
            for (int i = 0; i < pathNodes.Count; i++)
            {
                //siblingIndex is the objects index in the hierarchy
                if(n.transform.GetSiblingIndex() < pathNodes[i].transform.GetSiblingIndex())
                {
                    pathNodes.Insert(i, n);
                    didInsert = true;
                    break;
                }
            }

            if (!didInsert)
            {
                pathNodes.Add(n);
            }           
        }
    }


    /**
     * This only fires in Editor
     * and only when Scene view is showing
     * and only when the script component is expanded
     */
    void OnDrawGizmos()
    {
        populateNodes();

        for (int i = 0; i < pathNodes.Count; i++)
        {
            Vector3 pos = pathNodes[i].transform.position;

            if(i > 0)
            {
                Vector3 prevPos = pathNodes[i - 1].transform.position;
                Gizmos.DrawLine(prevPos, pos);
                Gizmos.DrawWireSphere(pos, 0.3f);
            }
        }
    }



}
