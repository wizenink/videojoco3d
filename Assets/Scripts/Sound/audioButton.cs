using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyTools.SoundManager;
using SoundCte;
using UnityEngine.UI;

public class audioButton : MonoBehaviour {

	// Update is called once per frame
	public void Play () {
		SoundManager.PlayUISound (SoundCte.SoundCte.loadAudioClip(SoundCte.SoundCte.CLICK_SOUND), 1.0f);
		}
}
