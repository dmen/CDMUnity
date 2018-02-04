/*
 * Attached to theManager GameObject
 * all the AudioSources defined are children of the manager object
 * This is just a simple way of playing the audio on those sources
 */
using UnityEngine;
using System;
using System.Collections;


public class AudioManager : MonoBehaviour 
{
    private Action callback;
    private AudioSource source;
    private AudioSource sfxSource;
    private AudioClip clip;
    private AudioClip sfxClip;
    private bool isPlaying;
    private float startTime;
    private float endTime;

    private float sfxStartDelay;


	void Start () 
	{
        //audio sources attached to the camera
        source = GameObject.Find("playerAudio").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("playerSFX").GetComponent<AudioSource>();
       

        isPlaying = false;
	}
	

	public void playAudio(string aud, Action act, string sfx = "", float delayToPlaySFX = 0f)
	{       
        callback = act;
        isPlaying = true;
        clip = Resources.Load<AudioClip>("sound/" + aud);       
        startTime = Time.time;

        if (sfx != "")
        {
            sfxClip = Resources.Load<AudioClip>("sound/" + sfx);
            endTime = startTime + sfxClip.length + delayToPlaySFX;
            //play the vo then start the sfx at the delay time
            source.PlayOneShot(clip);
            LeanTween.delayedCall(delayToPlaySFX, playSFX);            
        }
        else
        {  
            endTime = startTime + clip.length;
            source.PlayOneShot(clip);
        }
	}


    private void playSFX()
    {
        sfxSource.volume = .3f;
        sfxSource.PlayOneShot(sfxClip);
    }
    

    private void Update()
    {
        if (isPlaying)
        {            
            if (Time.time > endTime)
            {
                isPlaying = false;
                callback();
            }                     
        }
        
    }

}
