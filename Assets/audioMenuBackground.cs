using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyTools.SoundManager;
using SoundCte;

public class audioMenuBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoundManager.PlayMusic (SoundCte.SoundCte.LoadAudioClip (SoundCte.SoundCte.MUSICA5_SOUND), 0.8f, true, true);
	}

	public void StopBackGround () {
		SoundManager.StopAllMusic ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
