﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    private AudioSource audioPlayer;

	void Start () {
        audioPlayer = this.GetComponent<AudioSource>();
	}
	
	public void Play(AudioClip sound)
    {
        audioPlayer.PlayOneShot(sound);
    }
}
