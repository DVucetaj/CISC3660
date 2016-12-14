using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogueScript : MonoBehaviour {

	public Button btnContinue, btnFalse;
	public Text dialText;
	public GameObject modalPanelObject;
	public int numDialogs = 1, maxDialogs = 1;
	public string[] leDialogs;
	public bool[] leAnswers;

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

	public void instantDia(string[] incDial, bool[] incAns, int numDial) {
		leDialogs = incDial;
		leAnswers = incAns;
		numDialogs = numDial;
		maxDialogs = numDial;
		continueClick (leDialogs [0]);
	}

	public void continueClick(string incText)
	{
		modalPanelObject.SetActive (true);
		GameObject.Find ("scoreText").GetComponent<Text> ().text = "SCORE: " + PlayerPrefs.GetInt("currScore");
		btnContinue.onClick.RemoveAllListeners();
		btnFalse.onClick.RemoveAllListeners();
		this.dialText.text = incText;
		btnContinue.gameObject.SetActive (true);
		btnFalse.gameObject.SetActive (true);
		if (numDialogs <= 1) { //The final prompt
			if (leAnswers [maxDialogs - numDialogs]) { //If the answer is TRUE
				btnContinue.onClick.AddListener (() => addScore(10));
				btnContinue.onClick.AddListener (() => PostScriptum());
				btnFalse.onClick.AddListener(() => removeScore(10*(maxDialogs-numDialogs)));
			} else { //The answer is FALSE
				btnContinue.onClick.AddListener(() => removeScore(10*(maxDialogs-numDialogs)));
				btnFalse.onClick.AddListener (() => addScore(10));
				btnFalse.onClick.AddListener (() => PostScriptum());
			}
			btnContinue.onClick.AddListener (ClosePanel);
			btnFalse.onClick.AddListener (ClosePanel);
		} else { //Not the final prompt
			if (leAnswers [maxDialogs - numDialogs]) { //If the answer is TRUE
				numDialogs--;
				btnContinue.onClick.AddListener (() => addScore(10));
				btnContinue.onClick.AddListener (() => continueClick (leDialogs [maxDialogs - numDialogs]));
				btnFalse.onClick.AddListener(() => removeScore(10*(maxDialogs-numDialogs-1)));
				btnFalse.onClick.AddListener (ClosePanel);
			} else { //The answer is FALSE
				numDialogs--;
				btnContinue.onClick.AddListener(() => removeScore(10*(maxDialogs-numDialogs-1)));
				btnContinue.onClick.AddListener(ClosePanel);
				btnFalse.onClick.AddListener (() => addScore(10));
				btnFalse.onClick.AddListener (() => continueClick (leDialogs [maxDialogs - numDialogs]));
			}
		}
	}

	public void ClosePanel()
	{
		modalPanelObject.SetActive (false);
		Time.timeScale = 1.00f;
	}

	public void addScore(int scoreToAdd) {
		int currScore = PlayerPrefs.GetInt ("currScore");
		currScore += scoreToAdd;
		PlayerPrefs.SetInt ("currScore", currScore);
		GameObject.Find ("scoreText").GetComponent<Text> ().text = "SCORE: " + currScore;
	}

	public void removeScore(int scoreToRemove) {
		int currScore = PlayerPrefs.GetInt ("currScore");
		currScore -= scoreToRemove;
		PlayerPrefs.SetInt ("currScore", currScore);
		GameObject.Find ("scoreText").GetComponent<Text> ().text = "SCORE: " + currScore;
	}

	public void PostScriptum() {
		Destroy(GameObject.Find ("Clerk Hitbox").GetComponent<NPCColl> ());
		Destroy(GameObject.Find ("Clerk Hitbox").GetComponent<TestScript> ());
		GameObject.Find ("Clerk Hitbox").AddComponent(typeof(NPCCollSimple));
		GameObject.Find ("Clerk Hitbox").GetComponent<RealScript> ().TextCtn ();
		if (SceneManager.GetActiveScene ().name == "mariScene") { //dispensary
			PlayerPrefs.SetInt("mariSceneQuest", 1); //use int as a boolean [0:false;1:true]
		} else if (SceneManager.GetActiveScene ().name == "barScene") { //dispensary
			PlayerPrefs.SetInt("barSceneQuest", 1); //use int as a boolean [0:false;1:true]
		} else if (SceneManager.GetActiveScene ().name == "pharmScene") { //dispensary
			PlayerPrefs.SetInt("pharmSceneQuest", 1); //use int as a boolean [0:false;1:true]
		}

	}

}
