using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToLevel : MonoBehaviour{

	public string toScene;

	void OnCollisionEnter2D(Collision2D player)
	{
		if (player.gameObject.tag == "Player") {
			if (SceneManager.GetSceneByName (toScene).isLoaded)
				SceneManager.SetActiveScene (SceneManager.GetSceneByName (toScene));
			else
				SceneManager.LoadSceneAsync (toScene);
		}
	}
}
