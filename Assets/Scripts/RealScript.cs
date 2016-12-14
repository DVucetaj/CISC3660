using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class RealScript : MonoBehaviour {
	private OkayScript okayScript;
	private DisplayManager displayManager;
	public string[] textInput;
	public int numDial = 1;

	private UnityAction myCtnAction;

	private static RealScript realScript;

	public static RealScript Instance ()
	{
		if (!realScript) {
			realScript = FindObjectOfType (typeof(RealScript)) as RealScript;
			if (!realScript)
				Debug.LogError ("There needs to be one active RealScript in a GameObject on your scene.");
		}
		return realScript;
	}

	void Awake()
	{
		okayScript = OkayScript.Instance ();
		displayManager = DisplayManager.Instance ();
	}

	public void TextCtn()
	{
		Time.timeScale = 0.00f;
		okayScript.instantDia (textInput, numDial);
	}
}
