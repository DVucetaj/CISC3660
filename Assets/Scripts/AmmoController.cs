using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AmmoController : MonoBehaviour {

	public GameObject ammo, dieMenu;

	public int fireCD, fireCooldown;
	public int eHP, mHP;

	// Use this for initialization
	void Start () {
		eHP = 3;
		mHP = 3;
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		if (fireCD > 0)
			fireCD -= 1;
		if (fireCD < 0)
			fireCD = 0;

		if (fireCD <= 0) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SpawnAmmo ();
			}
		}
	}

	void SpawnAmmo() {
		if (fireCD <= 0) {
			fireCD = fireCooldown;
			Vector2 pos;
			pos = new Vector2 (transform.position.x, transform.position.y +0.036f);
			GameObject Clone;
			Clone = (Instantiate (ammo, pos, Quaternion.identity)) as GameObject;
			AmmoAI other = (AmmoAI)Clone.GetComponent (typeof(AmmoAI));
			other.isOriginal = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy Ammo") {
			eHP--;
			GameObject.Find ("Protagonist HP").GetComponent<Slider> ().value = eHP;
			other.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other);

			if (eHP <= 0) {
				transform.Rotate (new Vector3 (90, 0));
				PlayerPrefs.SetInt ("bossDefeated", 0);
				Time.timeScale = 0.00f;
				dieMenu.SetActive (true);
			}
		}
	}

	public void RetryBattle() {
		Time.timeScale = 1.00f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		PlayerPrefs.SetInt ("bossDefeated", 0);
	}
}
