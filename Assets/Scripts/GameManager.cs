using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static string playerNamer;
	public static bool mariPass, barPass, pharmPass, isHigh, isDrunk,isDead;

	public static GameManager instance = null;

	private static int playerScore;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
