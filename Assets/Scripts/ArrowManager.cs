using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArrowManager : MonoBehaviour
{
    public List<GameObject> arrows;
    private Action callback;

    private void Start()
    {
        GameObject[] aros = GameObject.FindGameObjectsWithTag("arrow");
        arrows = new List<GameObject>();

        for (int j = 0; j < aros.Length; j++)
        {
            GameObject n = aros[j];
            Vector3 pos = n.transform.position;
            pos.y -= .5f;//move under the floor
            n.transform.position = pos;
            //n.SetActive(false);

            bool didInsert = false;
            for (int i = 0; i < arrows.Count; i++)
            {
                //siblingIndex is the objects index in the hierarchy
                if (n.transform.GetSiblingIndex() < arrows[i].transform.GetSiblingIndex())
                {
                    arrows.Insert(i, n);
                    didInsert = true;
                    break;
                }
            }

            if (!didInsert)
            {
                arrows.Add(n);
            }
        }
    }


    public void showArrows(Action act)
    {
        callback = act;

        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows.Count - 1; i++)
        {
            n = arrows[i];
           pos = n.transform.position;
            pos.y += .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeOutBack);
        }

        //the very last arrow - 
        n = arrows[arrows.Count - 1];
        pos = n.transform.position;
        pos.y += .5f;
        LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeOutBack).setOnComplete(done);
    }
    

    void done()
    {
        callback();
    }

}
