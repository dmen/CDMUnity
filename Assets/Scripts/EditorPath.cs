using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPath : MonoBehaviour
{
    public List<GameObject> pathNodes;

    void OnDrawGizmos()
    {
        pathNodes = new List<GameObject>();
        pathNodes.Add(GameObject.Find("node0"));
        pathNodes.Add(GameObject.Find("nodep5"));
        pathNodes.Add(GameObject.Find("node1"));
        pathNodes.Add(GameObject.Find("node2"));
        pathNodes.Add(GameObject.Find("node3"));
        pathNodes.Add(GameObject.Find("node4"));
        pathNodes.Add(GameObject.Find("node5"));
        pathNodes.Add(GameObject.Find("node6"));
        pathNodes.Add(GameObject.Find("node7"));
        pathNodes.Add(GameObject.Find("node8"));
        pathNodes.Add(GameObject.Find("node9"));
        pathNodes.Add(GameObject.Find("node10"));
        pathNodes.Add(GameObject.Find("node11"));
        pathNodes.Add(GameObject.Find("node12"));
        pathNodes.Add(GameObject.Find("node13"));
        pathNodes.Add(GameObject.Find("node14"));

        for(int i = 0; i < pathNodes.Count; i++)
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
