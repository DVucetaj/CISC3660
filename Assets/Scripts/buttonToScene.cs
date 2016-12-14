using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonToScene : MonoBehaviour {

	public string sceneName;

	public void onClickToScene()
	{

		SceneManager.LoadScene (sceneName);
		SceneManager.SetActiveScene (SceneManager.GetSceneByName(sceneName));
		//SceneManager.LoadScene ("pharmScene", LoadSceneMode.Additive);
	}
}
