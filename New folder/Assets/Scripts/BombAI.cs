using UnityEngine;
using System.Collections;

public class BombAI : MonoBehaviour {

	public bool isOriginal = true;

	// Use this for initialization
	void Start () {
		if (!isOriginal) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.00f, -0.36f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -0.45f) {
			Destroy (gameObject);
		}
	
	}
}
