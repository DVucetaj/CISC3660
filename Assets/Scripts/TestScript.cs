using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestScript : MonoBehaviour {
	private DialogueScript dialogueScript;
	private DisplayManager displayManager;

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
		myCtnAction = new UnityAction (TestCtnAction);
	}

	public void TextCtn()
	{
		dialogueScript.continueClick ("Hello, I'm an alien. Would you like to buy some drugs?", myCtnAction);
	}

	void TestCtnAction()
	{
		displayManager.DisplayMessage ("Okay...");
	}
}
