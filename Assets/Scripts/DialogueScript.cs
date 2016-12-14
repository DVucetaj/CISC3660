using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DialogueScript : MonoBehaviour {

	public Button btnContinue;
	public Text dialText;
	public GameObject modalPanelObject;

	private static DialogueScript dialogueScript;

	public static DialogueScript Instance ()
	{
		if (!dialogueScript) {
			dialogueScript = FindObjectOfType (typeof(DialogueScript)) as DialogueScript;
			if (!dialogueScript)
				Debug.LogError ("There needs to be one active DialogueScript in a GameObject on your scene.");
		}
		return dialogueScript;
	}

	public void continueClick(string incText, UnityAction ctnEvent)
	{
		modalPanelObject.SetActive (true);
		btnContinue.onClick.RemoveAllListeners();
		btnContinue.onClick.AddListener (ctnEvent);
		btnContinue.onClick.AddListener (ClosePanel);
		this.dialText.text = incText;
		btnContinue.gameObject.SetActive (true);
	}

	void ClosePanel()
	{
		modalPanelObject.SetActive (false);
	}
}
