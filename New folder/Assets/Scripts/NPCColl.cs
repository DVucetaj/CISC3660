using UnityEngine;
using System.Collections;

public class NPCColl : MonoBehaviour {

	private TestScript testScript;

	void Awake()
	{
		testScript = TestScript.Instance ();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
			testScript.TextCtn ();
	}
}