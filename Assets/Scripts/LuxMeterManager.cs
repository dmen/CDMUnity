using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuxMeterManager : MonoBehaviour
{
    //for changing the number colors
    public Sprite spNo;
    public Sprite sp400;
    public Sprite sp250;
    public Sprite sp125;
    public Sprite sp50;
    public Sprite sp10;
    public Sprite sp4;
    public Sprite sp1;

    public Sprite blackArrow;
    public Sprite whiteArrow;

    GameObject mainLux; //for setting active on
    CanvasGroup luxMeter;
    Image arrow;
    RectTransform arrowTran;
    CanvasGroup arrowCan;
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

    CanvasGroup scoresCG;//for fading out when done
    Image scores;//to change fill amt

    RectTransform bgRect;


    void Awake ()
    {
        mainLux = transform.gameObject;

        luxMeter = GetComponent<CanvasGroup>();

        player = GameObject.Find("Player");
        arrow = GameObject.Find("luxArrow").GetComponent<Image>();
        arrowTran = GameObject.Find("luxArrow").GetComponent<RectTransform>();
        arrowCan = GameObject.Find("luxArrow").GetComponent<CanvasGroup>();

        bar400 = GameObject.Find("bar400").GetComponent<Image>();
        bar250 = GameObject.Find("bar250").GetComponent<Image>();
        bar125 = GameObject.Find("bar125").GetComponent<Image>();
        bar50 = GameObject.Find("bar50").GetComponent<Image>();
        bar10 = GameObject.Find("bar10").GetComponent<Image>();
        bar4 = GameObject.Find("bar4").GetComponent<Image>();
        bar1 = GameObject.Find("bar1").GetComponent<Image>();

        numbers = GameObject.Find("numbers").GetComponent<Image>();

        scoresCG = GameObject.Find("scores").GetComponent<CanvasGroup>();
        scores = GameObject.Find("scores").GetComponent<Image>();

        bgRect = GameObject.Find("bgRect").GetComponent<RectTransform>();

        arrowCan.alpha = 0f;

        bar400.fillAmount = .15f;
        bar250.fillAmount = .15f;
        bar125.fillAmount = .15f;
        bar50.fillAmount = .15f;
        bar10.fillAmount = .15f;
        bar4.fillAmount = .15f;
        bar1.fillAmount = .15f;

        scores.fillAmount = 0f;
        scoresCG.alpha = 1;
    }

    
    public void hideMeter(bool fast = false)
    {
        if (fast)
        {
            luxMeter.alpha = 0f;
            hideLux();
        }
        else
        {
            LeanTween.alphaCanvas(luxMeter, 0f, 1f).setOnComplete(hideLux);           
        }        
    }

    void hideLux()
    {
        mainLux.SetActive(false);
        scores.fillAmount = 0f;
        scoresCG.alpha = 1;
    }

    public void showMeter()
    {
        mainLux.SetActive(true);
        LeanTween.alphaCanvas(luxMeter, 1f, 1f);
    }

    public void lux400()
    {
        arrowCan.alpha = 1f;
        curPos = arrowTran.localPosition;
        curBar = bar400;
        numbers.sprite = sp400;
        arrow.sprite = blackArrow;
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, .538f, changeTime).setEase(ease);
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
        LeanTween.value(player, tweenPos, arrowTran.localPosition.y, -0.135f, changeTime).setEase(ease);
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

    public void noLux(bool setBar1 = false)
    {
        numbers.sprite = spNo;
        LeanTween.alphaCanvas(arrowCan, 0f, .5f);
        if (setBar1)
        {
            LeanTween.value(player, tweenFill, 1f, .15f, fillTime);//sets curBar which is bar1
        }
    }

    public void showScores()
    {
        LeanTween.value(player, fill400, .15f, 1f, .25f);
        LeanTween.value(player, fill250, .15f, 1f, .25f).setDelay(.1f);
        LeanTween.value(player, fill125, .15f, 1f, .25f).setDelay(.2f);
        LeanTween.value(player, fill50, .15f, 1f, .25f).setDelay(.3f);
        LeanTween.value(player, fill10, .15f, 1f, .25f).setDelay(.4f);
        LeanTween.value(player, fill4, .15f, 1f, .25f).setDelay(.5f);
       // LeanTween.value(player, fill1, .15f, 1f, .25f).setDelay(.6f);

        LeanTween.scale(bgRect, new Vector3(1.47f, 1, 1), .25f);
        LeanTween.value(player, fillScores, 0f, 1f, 3f);
    }
    void fillScores(float val)
    {
        scores.fillAmount = val;
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

    void fill400(float val)
    {
        bar400.fillAmount = val;
    }
    void fill250(float val)
    {
        bar250.fillAmount = val;
    }
    void fill125(float val)
    {
        bar125.fillAmount = val;
    }
    void fill50(float val)
    {
        bar50.fillAmount = val;
    }
    void fill10(float val)
    {
        bar10.fillAmount = val;
    }
    void fill4(float val)
    {
        bar4.fillAmount = val;
    }
    void fill1(float val)
    {
        bar1.fillAmount = val;
    }

}
