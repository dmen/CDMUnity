using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{

    GameObject[] lines;

	void Start ()
    {
        lines = new GameObject[17];
        lines[0] = GameObject.Find("l1");
        lines[1] = GameObject.Find("l2");
        lines[2] = GameObject.Find("l3");
        lines[3] = GameObject.Find("l4");
        lines[4] = GameObject.Find("l5");
        lines[5] = GameObject.Find("l6");
        lines[6] = GameObject.Find("l7");
        lines[7] = GameObject.Find("l8");
        lines[8] = GameObject.Find("l9");
        lines[9] = GameObject.Find("l10");
        lines[10] = GameObject.Find("l11");
        lines[11] = GameObject.Find("l12");
        lines[12] = GameObject.Find("l13");
        lines[13] = GameObject.Find("l14");
        lines[14] = GameObject.Find("l15");
        lines[15]= GameObject.Find("l16");
        lines[16] = GameObject.Find("l17");

        for(int i = 0; i < lines.Length; i++)
        {
            lines[i].transform.localScale = new Vector3(1, 1, 0);
        }        

        LeanTween.delayedCall(2f, startDrawing);
    }
	

	void startDrawing()
    {
        for(int i = 0; i < lines.Length; i++)
        {
            LeanTween.scale(lines[i], new Vector3(1, 1, 1), 2f).setDelay(i * .5f);
        }
    }
}
