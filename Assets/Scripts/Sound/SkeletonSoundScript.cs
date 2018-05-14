using System.Collections.Generic;
using UnityEngine;
using SoundUtil;
using System.Collections;

public class SkeletonSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		StartCoroutine(waiter());
	}

	IEnumerator waiter()
	{
		while (true) {
			PlaySound ();

			//Wait for 4 seconds
			yield return new WaitForSeconds (7);

		}
	}

	// Update is called once per frame
	void Update () {

	}

	private void PlaySound(){
		GameObject gO = GameObject.Find ("Enemy");
		if (gO != null) {
			SoundUtil.SoundUtil.PlayRandomSkeletonWhisp (gO.transform);
		}
	}
}