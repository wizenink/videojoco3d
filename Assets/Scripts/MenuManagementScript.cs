using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EazyTools.SoundManager;

public class MenuManagementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)){
			OnResume();
		}
	}

	public void OnResume(){
		Level1Script level1 = FindObjectOfType<Level1Script> ();
		if (level1 != null) {
			level1.paused = false;
		} else {

            //Level2Script level2 = FindObjectOfType<Level2Script> ();
			//level2 = FindObjectOfType<Level2Script> ();
		}
		SoundManager.globalMusicVolume = 1F;
		SceneManager.UnloadSceneAsync ("PauseMenu");
	}
}
