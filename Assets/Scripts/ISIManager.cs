using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ISIManager : MonoBehaviour
{
    GameObject panels;
    int panelIndex;

    private void Start()
    {
        //GvrCardboardHelpers.Recenter();

        panelIndex = 1;
        panels = GameObject.Find("panels");
    }

    public void leftSlide()
    {
        if(panelIndex > 1)
        { 
            Vector3 pos = panels.transform.position;
            pos.x += 650f;

            LeanTween.move(panels, pos, 1f).setEase(LeanTweenType.easeOutBack);

            panelIndex--;
        }
    }


    public void rightSlide()
    {
        if (panelIndex < 7)
        {
            Vector3 pos = panels.transform.position;
            pos.x -= 650f;

            LeanTween.move(panels, pos, 1f).setEase(LeanTweenType.easeOutBack);

            panelIndex++;
        }
    }


    public void begin()
    {
        SceneManager.LoadScene(2);//Hall
    }
}
