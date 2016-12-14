using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClerkScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int hasTakenQuest = 0;
		if (SceneManager.GetActiveScene ().name == "mariScene") {
			hasTakenQuest = PlayerPrefs.GetInt ("mariSceneQuest");
			if (hasTakenQuest == 1) {
				Destroy (GameObject.Find ("Clerk Hitbox").GetComponent<NPCColl> ());
				Destroy (GameObject.Find ("Clerk Hitbox").GetComponent<TestScript> ());
				GameObject.Find ("Clerk Hitbox").AddComponent (typeof(NPCCollSimple));
			}
		} else if (SceneManager.GetActiveScene ().name == "pharmScene") {
			hasTakenQuest = PlayerPrefs.GetInt ("pharmSceneQuest");
			if (hasTakenQuest == 1) {
				Destroy (GameObject.Find ("Clerk Hitbox").GetComponent<NPCColl> ());
				Destroy (GameObject.Find ("Clerk Hitbox").GetComponent<TestScript> ());
				GameObject.Find ("Clerk Hitbox").AddComponent (typeof(NPCCollSimple));
			}
		} else if (SceneManager.GetActiveScene ().name == "barScene") {
			hasTakenQuest = PlayerPrefs.GetInt ("barSceneQuest");
			if (hasTakenQuest == 1) {
				Destroy (GameObject.Find ("Clerk Hitbox").GetComponent<NPCColl> ());
				Destroy (GameObject.Find ("Clerk Hitbox").GetComponent<TestScript> ());
				GameObject.Find ("Clerk Hitbox").AddComponent (typeof(NPCCollSimple));
			}
		}  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
