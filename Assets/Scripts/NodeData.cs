using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attached to all nodes in the path

public class NodeData : MonoBehaviour
{
    public float timeToNextNode;
    public string nodeName;
    public bool ease;
    public bool waitAtNode;
    public float rotation;
}
