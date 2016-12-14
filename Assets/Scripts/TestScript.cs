using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestScript : MonoBehaviour {
	private DialogueScript dialogueScript;
	private DisplayManager displayManager;
	public string[] textInput;
	public bool[] answers;
	public int numDial = 1;

	private UnityAction myCtnAction;

	private static TestScript testScript;

	public static TestScript Instance ()
	{
		if (!testScript) {
			testScript = FindObjectOfType (typeof(TestScript)) as TestScript;
			if (!testScript)
				Debug.LogError ("There needs to be one active TestScript in a GameObject on your scene.");
		}
		return testScript;
	}

	void Awake()
	{
		dialogueScript = DialogueScript.Instance ();
		displayManager = DisplayManager.Instance ();
	}

	public void TextCtn()
	{
		Time.timeScale = 0.00f;
		dialogueScript.instantDia (textInput, answers, numDial);
	}
}
