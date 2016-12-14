using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NPCCollSimple : MonoBehaviour {

	public RealScript realScript;

	void Awake()
	{
		if (gameObject.tag == "Clerk") {
			realScript = gameObject.GetComponent<RealScript> ();
		}
		//	realScript = RealScript.Instance ();
	}

	void Update() {
		if (gameObject.tag == "NPC") {
			int hasTakenQuest = 0;
			if (SceneManager.GetActiveScene ().name == "mariScene") {
				hasTakenQuest = PlayerPrefs.GetInt ("mariSceneQuest");
				if (hasTakenQuest == 1) {
					realScript = GameObject.Find ("AlienScript2").GetComponent<RealScript> ();
				}
			} else if (SceneManager.GetActiveScene ().name == "pharmScene") {
				hasTakenQuest = PlayerPrefs.GetInt ("pharmSceneQuest");
				if (hasTakenQuest == 1) {
					realScript = GameObject.Find ("AlienScript2").GetComponent<RealScript> ();
				}
			} else if (SceneManager.GetActiveScene ().name == "barScene") {
				hasTakenQuest = PlayerPrefs.GetInt ("barSceneQuest");
				if (hasTakenQuest == 1) {
					realScript = GameObject.Find ("AlienScript2").GetComponent<RealScript> ();
				}
			}
			if (SceneManager.GetActiveScene().name != "alleyScene" && PlayerPrefs.GetInt ("mariSceneQuest") == 1 && 
				PlayerPrefs.GetInt ("pharmSceneQuest") == 1 && PlayerPrefs.GetInt ("barSceneQuest") == 1) {
				realScript = GameObject.Find ("AlienScript3").GetComponent<RealScript> ();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" && Time.timeScale != 0.00f) {
			if (gameObject.tag == "NPC" && SceneManager.GetActiveScene().name == "mariScene" && PlayerPrefs.GetInt ("mariSceneQuest") == 1 &&
				PlayerPrefs.GetInt ("pharmSceneQuest") == 1 && PlayerPrefs.GetInt ("barSceneQuest") == 1) {
				PlayerPrefs.SetInt ("enterTheChambers", 1);
			}
			realScript.TextCtn ();
		}
	}
}
