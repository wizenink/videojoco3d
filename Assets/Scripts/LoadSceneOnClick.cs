using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public static string currentLevel;

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

	public void LoadByName()
	{
		SceneManager.LoadScene(currentLevel);
	}
}