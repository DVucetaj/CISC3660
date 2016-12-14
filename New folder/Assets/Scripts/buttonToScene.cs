using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonToScene : MonoBehaviour {

	public string sceneName;
	public InputField playerName;


	public void onClickToScene()
	{
		if (sceneName == "mainScene") {

			if (playerName.text != null && playerName.text.Length > 0) {
				PlayerPrefs.SetString ("playername", playerName.text);
				SceneManager.LoadScene (sceneName);
				SceneManager.SetActiveScene (SceneManager.GetSceneByName (sceneName));
			} 
		} else {
				PlayerPrefs.SetString ("playername", playerName.text);
				SceneManager.LoadScene (sceneName);
				SceneManager.SetActiveScene (SceneManager.GetSceneByName (sceneName));
		}

	}
}
