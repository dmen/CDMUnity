using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArrowManager : MonoBehaviour
{

    GameObject player;
    public List<GameObject> arrows;
    private Action callback;
    private GameObject arrowParent;
    GameObject[] aros;

    private void Start()
    {
        player = GameObject.Find("Player");
        arrowParent = GameObject.Find("arrows");

       aros = GameObject.FindGameObjectsWithTag("arrow");
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

    public void fadeOutArrows()
    {        
        LeanTween.value(player, setArrowAlpha, 1f, 0f, 2f).setOnComplete(killArrows);
    }
    public void fadeInArrows()
    {
        arrowParent.SetActive(true);
        LeanTween.value(player, setArrowAlpha, 0f, 1f, 2f);
    }
    void setArrowAlpha(float val)
    {
        for (int i = 0; i < aros.Length; i++)
        {
            aros[i].GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0, val));
        }
    }

    void killArrows()
    {
        arrowParent.SetActive(false);
    }

    public void showArrows(Action act = null)
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

        //the very last arrow - so we can use OnComplete
        n = arrows[arrows.Count - 1];
        pos = n.transform.position;
        pos.y += .5f;
        LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeOutBack).setOnComplete(done);
    }
    

    void done()
    {
        if (callback != null)
        {
            callback();
        }
       
    }

}
