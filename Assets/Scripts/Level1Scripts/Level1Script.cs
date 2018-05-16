using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EazyTools.SoundManager;

public class Level1Script : MonoBehaviour {

	private Player player;
	public bool paused = false;
	// Use this for initialization
	void Start () {
		LoadSceneOnClick.currentLevel = "level1";
		if (GameObject.Find ("EmptyPlayerCompleto") != null) {
			player = GameObject.Find ("EmptyPlayerCompleto").GetComponent <Player> ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (!paused) {
			Time.timeScale = 1;
			player.enabled = true;
			if (Input.GetKeyDown (KeyCode.Escape)) {
				player.enabled = false;
				SoundManager.StopAllSounds ();
				SoundManager.globalMusicVolume = 0.3F;
				Time.timeScale = 0;
				paused = true;
				SceneManager.LoadScene ("PauseMenu", LoadSceneMode.Additive);
			}
		}
	}
}
