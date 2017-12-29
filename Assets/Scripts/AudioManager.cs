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
    private bool isPlaying;


	void Start () 
	{
        isPlaying = false;
	}
	

	public void playAudio(string aud, Action act)
	{
        callback = act;
        sourcePlaying = GameObject.Find(aud).GetComponent<AudioSource>();
        isPlaying = true;
        sourcePlaying.Play ();
	}    


    private void Update()
    {
        if (isPlaying)
        {
            float progress = Mathf.Clamp01(sourcePlaying.time / sourcePlaying.clip.length);

            if (progress == 1f)
            {
                isPlaying = false;
                callback();
            }
        }
    }

}
