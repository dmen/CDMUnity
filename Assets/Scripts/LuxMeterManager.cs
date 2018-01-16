using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuxMeterManager : MonoBehaviour
{
    //for changing the number colors
    public Sprite sp400;
    public Sprite sp250;
    public Sprite sp125;
    public Sprite sp50;
    public Sprite sp10;
    public Sprite sp4;
    public Sprite sp1;

    public Sprite blackArrow;
    public Sprite whiteArrow;

    CanvasGroup luxMeter;
    Image arrow;
    RectTransform arrowTran;
    Vector3 curPos;
    GameObject player;
    const float changeTime = .5f;
    const float fillTime = .5f;
    const LeanTweenType ease = LeanTweenType.easeOutBack;

    Image bar400;
    Image bar250;
    Image bar125;
    Image bar50;
    Image bar10;
    Image bar4;
    Image bar1;
    Image curBar;
    Image lastBar;
    Image numbers;

    void Awake ()
    {
        luxMeter = GetComponent<CanvasGroup>();
        player = GameObject.Find("Player");
        arrow = GameObject.Find("luxArrow").GetComponent<Image>();
        arrowTran = GameObject.Find("luxArrow").GetComponent<RectTransform>();

        bar400 = GameObject.Find("bar400").GetComponent<Image>();
        bar250 = GameObject.Find("bar250").GetComponent<Image>();
        bar125 = GameObject.Find("bar125").GetComponent<Image>();
        bar50 = GameObject.Find("bar50").GetComponent<Image>();
        bar10 = GameObject.Find("bar10").GetComponent<Image>();
        bar4 = GameObject.Find("bar4").GetComponent<Image>();
        bar1 = GameObject.Find("bar1").GetComponent<Image>();

        numbers = GameObject.Find("numbers").GetComponent<Image>();

        bar400.fillAmount = .15f;
        bar250.fillAmount = .15f;
        bar125.fillAmount = .15f;
        bar50.fillAmount = .15f;
        bar10.fillAmount = .15f;
        bar4.fillAmount = .15f;
        bar1.fillAmount = .15f;
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
        curBar = bar400;
        numbers.sprite = sp400;
        arrow.sprite = blackArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .543f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
    }


    public void lux250()
    {
        curPos = arrowTran.localPosition;
        curBar = bar250;
        lastBar = bar400;
        numbers.sprite = sp250;
        arrow.sprite = blackArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .37f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
        LeanTween.value(player, tweenLastFill, 1f, .15f, fillTime);
    }


    public void lux125()
    {
        curPos = arrowTran.localPosition;
        curBar = bar125;
        lastBar = bar250;
        numbers.sprite = sp125;
        arrow.sprite = blackArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .202f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
        LeanTween.value(player, tweenLastFill, 1f, .15f, fillTime);
    }


    public void lux50()
    {
        curPos = arrowTran.localPosition;
        curBar = bar50;
        lastBar = bar125;
        numbers.sprite = sp50;
        arrow.sprite = blackArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .033f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
        LeanTween.value(player, tweenLastFill, 1f, .15f, fillTime);
    }


    public void lux10()
    {
        curPos = arrowTran.localPosition;
        curBar = bar10;
        lastBar = bar50;
        numbers.sprite = sp10;
        arrow.sprite = whiteArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.13f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
        LeanTween.value(player, tweenLastFill, 1f, .15f, fillTime);
    }


    public void lux4()
    {
        curPos = arrowTran.localPosition;
        curBar = bar4;
        lastBar = bar10;
        numbers.sprite = sp4;
        arrow.sprite = whiteArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.3f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
        LeanTween.value(player, tweenLastFill, 1f, .15f, fillTime);
    }


    public void lux1()
    {
        curPos = arrowTran.localPosition;
        curBar = bar1;
        lastBar = bar4;
        numbers.sprite = sp1;
        arrow.sprite = whiteArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.47f, changeTime).setEase(ease);
        LeanTween.value(player, tweenFill, .15f, 1f, fillTime);
        LeanTween.value(player, tweenLastFill, 1f, .15f, fillTime);
    }





    void tweenPos(float val)
    {
        curPos.y = val;
        arrowTran.localPosition = curPos;
    }

    void tweenFill(float val)
    {
        curBar.fillAmount = val;
    }
    void tweenLastFill(float val)
    {
        lastBar.fillAmount = val;
    }

}
