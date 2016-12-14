using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossAI : MonoBehaviour {

	public GameObject bomb;

	public float eHP, mHP;

	public int fireCD, fireCooldown;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2(0.144f, 0.0f);
		eHP = 1000.0f;
		mHP = 1000.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 0.07f) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2(-0.144f, 0.0f);
		} else if (transform.position.x < -.15f) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0.144f, 0.0f);
		}
	
	}

	void FixedUpdate() {
		if (fireCD > 0)
			fireCD -= 1;
		if (fireCD < 0)
			fireCD = 0;

		if (fireCD <= 0) {
			SpawnBomb ();
		}
	}

	void SpawnBomb() {
		if (fireCD <= 0) {
			fireCD = fireCooldown;
			Vector2 pos;
			pos = new Vector2 (transform.position.x, transform.position.y -0.036f);
			GameObject Clone;
			Clone = (Instantiate (bomb, pos, Quaternion.identity)) as GameObject;
			BombAI other = (BombAI)Clone.GetComponent (typeof(BombAI));
			other.isOriginal = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player Ammo") {
			eHP -= 30.0f;
			GameObject.Find ("Boss HP").GetComponent<Slider> ().value = eHP;
			other.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other);

			if (eHP <= 0) {
				GetComponent<SpriteRenderer> ().enabled = false;
				Destroy (gameObject);
				PlayerPrefs.SetInt ("bossDefeated", 1);
			}
		}
	}
}
