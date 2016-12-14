using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeginBonus : MonoBehaviour {

	public Text checkThis, leText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RedText() {
		//This enables the error text if no name is entered
		if (checkThis.text.Length <= 0) {
			leText.gameObject.SetActive (true);
		}
	}

	public void InitVars() {
		PlayerPrefs.SetInt ("currScore", 0);
		PlayerPrefs.SetInt ("mariSceneQuest", 0);
		PlayerPrefs.SetInt ("pharmSceneQuest", 0);
		PlayerPrefs.SetInt ("barSceneQuest", 0);
		PlayerPrefs.SetInt ("enterTheChambers", 0);
		PlayerPrefs.SetInt ("bossDefeated", 0);
	}
}
