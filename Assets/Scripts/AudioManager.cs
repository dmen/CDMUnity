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
	private AudioSource intro;
    private Action callback;
    private AudioSource sourcePlaying;

	void Start () 
	{
		intro = GameObject.Find ("audIntro").GetComponent<AudioSource> ();
	}
	
	public void playIntro(Action act)
	{
        callback = act;
        sourcePlaying = intro;
		intro.Play ();
	}

    private void Update()
    {
        float progress = Mathf.Clamp01(sourcePlaying.time / sourcePlaying.clip.length);

        if (progress == 1f)
        {
            callback();
        }
    }

}
