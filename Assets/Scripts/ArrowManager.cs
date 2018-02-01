using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArrowManager : MonoBehaviour
{
    GameObject player;

    List<GameObject> arrows;//course 10
    List<GameObject> arrows5;
    List<GameObject> arrows11;
    
    private GameObject arrowHolder10;
    private GameObject arrowHolder5;
    private GameObject arrowHolder11;


    private void Start()
    {
        player = GameObject.Find("Player");

        //holders used for setting active state
        arrowHolder10 = GameObject.Find("arrows");
        arrowHolder5 = GameObject.Find("arrows5");
        arrowHolder11 = GameObject.Find("arrows11");

        //Sort course 10 arrows
        GameObject[] aros = GameObject.FindGameObjectsWithTag("arrow");
        arrows = new List<GameObject>();

        for (int j = 0; j < aros.Length; j++)
        {
            GameObject n = aros[j];
            Vector3 pos = n.transform.position;
            pos.y -= .5f;//move under the floor
            n.transform.position = pos;

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


        //sort course 5 arows
        aros = GameObject.FindGameObjectsWithTag("arrow5");
        arrows5 = new List<GameObject>();

        for (int j = 0; j < aros.Length; j++)
        {
            GameObject n = aros[j];
            Vector3 pos = n.transform.position;
            pos.y -= .5f;//move under the floor
            n.transform.position = pos;

            bool didInsert = false;
            for (int i = 0; i < arrows5.Count; i++)
            {
                //siblingIndex is the objects index in the hierarchy
                if (n.transform.GetSiblingIndex() < arrows5[i].transform.GetSiblingIndex())
                {
                    arrows5.Insert(i, n);
                    didInsert = true;
                    break;
                }
            }

            if (!didInsert)
            {
                arrows5.Add(n);
            }
        }


        //sort course 11 arrows
        aros = GameObject.FindGameObjectsWithTag("arrow11");
        arrows11 = new List<GameObject>();

        for (int j = 0; j < aros.Length; j++)
        {
            GameObject n = aros[j];
            Vector3 pos = n.transform.position;
            pos.y -= .5f;//move under the floor
            n.transform.position = pos;

            bool didInsert = false;
            for (int i = 0; i < arrows11.Count; i++)
            {
                //siblingIndex is the objects index in the hierarchy
                if (n.transform.GetSiblingIndex() < arrows11[i].transform.GetSiblingIndex())
                {
                    arrows11.Insert(i, n);
                    didInsert = true;
                    break;
                }
            }

            if (!didInsert)
            {
                arrows11.Add(n);
            }
        }

        arrowHolder5.SetActive(false);
        arrowHolder11.SetActive(false);
    }



    public void fadeOutArrows()
    {        
        LeanTween.value(player, setArrowAlpha, 1f, 0f, 2f).setOnComplete(killArrows);
    }
    public void fadeInArrows()
    {
        arrowHolder10.SetActive(true);
        LeanTween.value(player, setArrowAlpha, 0f, 1f, 2f);
    }
    void setArrowAlpha(float val)
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            arrows[i].GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0, val));
        }
    }


    void killArrows()
    {
        arrowHolder10.SetActive(false);
    }


    public void killExtras()
    {
        arrowHolder5.SetActive(false);
        arrowHolder11.SetActive(false);
    }


    public void showArrows10()
    {
        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows.Count; i++)
        {
            n = arrows[i];
            pos = n.transform.position;
            pos.y += .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeOutBack);
        }
    }

    //put course10 arrows under the grid
    public void hideArrows10()
    {
        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows.Count; i++)
        {
            n = arrows[i];
            pos = n.transform.position;
            pos.y -= .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeInBack);
        }
    }

    //show course 10 arrows
    public void showArrows5()
    {
        arrowHolder5.SetActive(true);

        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows5.Count; i++)
        {
            n = arrows5[i];
            pos = n.transform.position;
            pos.y += .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeOutBack);
        }
    }

    public void hideArrows5()
    {
        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows5.Count; i++)
        {
            n = arrows5[i];
            pos = n.transform.position;
            pos.y -= .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeInBack);
        }
    }


    //show course 11 arrows
    public void showArrows11()
    {
        arrowHolder11.SetActive(true);

        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows11.Count; i++)
        {
            n = arrows11[i];
            pos = n.transform.position;
            pos.y += .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeOutBack);
        }
    }

    public void hideArrows11()
    {
        GameObject n;
        Vector3 pos;
        int i;

        for (i = 0; i < arrows11.Count; i++)
        {
            n = arrows11[i];
            pos = n.transform.position;
            pos.y -= .5f;
            LeanTween.move(n, pos, .5f).setDelay(1.5f + i * .05f).setEase(LeanTweenType.easeInBack);
        }
    }



}
