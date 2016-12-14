using UnityEngine;
using System.Collections;

public class FinalEncounter : MonoBehaviour {
	public RealScript rs;

	// Use this for initialization
	void Start () {
		GameObject.Find ("Alien[NPC]").GetComponent<RealScript> ().TextCtn ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (PlayerPrefs.GetInt ("bossDefeated") == 1) {
			if (other.gameObject.tag == "Player") {
				rs.TextCtn ();
			}
		}
	}
}
