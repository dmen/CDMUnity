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
    private bool isPlaying;


	void Start () 
	{
        source = GameObject.Find("playerAudio").GetComponent<AudioSource>();
        isPlaying = false;
	}
	

	public void playAudio(string aud, Action act)
	{       
        callback = act;
        isPlaying = true;
        source.clip = Resources.Load<AudioClip>("sound/" + aud);
        source.Play();
	}    


    private void Update()
    {
        if (isPlaying)
        {
            float progress = Mathf.Clamp01(source.time / source.clip.length);

            if (progress == 1f)
            {
                isPlaying = false;
                callback();
            }
        }
        
    }

}
