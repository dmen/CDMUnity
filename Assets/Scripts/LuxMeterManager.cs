using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuxMeterManager : MonoBehaviour
{
    CanvasGroup luxMeter;
    RectTransform arrowTran;
    Vector3 curPos;
    GameObject player;
    const float changeTime = .5f;
    const LeanTweenType ease = LeanTweenType.easeOutBack;


	void Awake ()
    {
        luxMeter = GetComponent<CanvasGroup>();
        player = GameObject.Find("Player");
        arrowTran = GameObject.Find("luxArrow").GetComponent<RectTransform>();
	}

    
    public void hideMeter(bool fast = false)
    {
        if (fast)
        {
            luxMeter.alpha = 0f;
        }
        else
        {
            LeanTween.value(player, setMeterAlpha, 1f, 0f, 1f);
        }        
    }


    public void showMeter()
    {
        LeanTween.value(player, setMeterAlpha, 0f, 1f, 1f);
    }


    void setMeterAlpha(float val)
    {
        luxMeter.alpha = val;
    }


    public void lux400()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .41f, changeTime).setEase(ease);
    }


    public void lux250()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .275f, changeTime).setEase(ease);
    }


    public void lux125()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .135f, changeTime).setEase(ease);
    }


    public void lux50()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .005f, changeTime).setEase(ease);
    }


    public void lux10()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.135f, changeTime).setEase(ease);
    }


    public void lux4()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.27f, changeTime).setEase(ease);
    }


    public void lux1()
    {
        curPos = arrowTran.localPosition;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.41f, changeTime).setEase(ease);
    }





    void tweenPos(float val)
    {
        curPos.y = val;
        arrowTran.localPosition = curPos;
    }


}
