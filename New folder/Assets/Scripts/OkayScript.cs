using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class OkayScript : MonoBehaviour {

	public Button btnContinue;
	public Text dialText;
	public GameObject modalPanelObject;
	public int numDialogs = 1, maxDialogs = 1;
	public string[] leDialogs;

	private static OkayScript okayScript;

	public static OkayScript Instance ()
	{
		if (!okayScript) {
			okayScript = FindObjectOfType (typeof(OkayScript)) as OkayScript;
			if (!okayScript)
				Debug.LogError ("There needs to be one active OkayScript in a GameObject on your scene.");
		}
		return okayScript;
	}

	public void instantDia(string[] incDial, int numDial) {
		leDialogs = incDial;
		numDialogs = numDial;
		maxDialogs = numDial;
		continueClick (leDialogs [0]);
	}

	public void continueClick(string incText)
	{
		modalPanelObject.SetActive (true);
		btnContinue.onClick.RemoveAllListeners();
		this.dialText.text = incText;
		numDialogs--;
		btnContinue.gameObject.SetActive (true);
		if (numDialogs <= 0) {
			btnContinue.onClick.AddListener (ClosePanel);
		} else {
			btnContinue.onClick.AddListener(() => continueClick (leDialogs [maxDialogs- numDialogs]));
		}
	}

	public void ClosePanel()
	{
		modalPanelObject.SetActive (false);
		Time.timeScale = 1.00f;
		//The following code runs to lead you to the boss level once you have unlocked it:
		if (PlayerPrefs.GetInt("enterTheChambers") == 1) {
			if (SceneManager.GetSceneByName ("alleyScene").isLoaded)
				SceneManager.SetActiveScene (SceneManager.GetSceneByName ("alleyScene"));
			else
				SceneManager.LoadSceneAsync ("alleyScene");
		}
		if (PlayerPrefs.GetInt ("bossDefeated") == 1) {
			//Reset variables before game ends
			PlayerPrefs.SetInt ("currScore", 0);
			PlayerPrefs.SetInt ("mariSceneQuest", 0);
			PlayerPrefs.SetInt ("pharmSceneQuest", 0);
			PlayerPrefs.SetInt ("barSceneQuest", 0);
			PlayerPrefs.SetInt ("enterTheChambers", 0);
			PlayerPrefs.SetInt ("bossDefeated", 0);
			//Game ends -> reload main menu
			if (SceneManager.GetSceneByName ("menuScene").isLoaded)
				SceneManager.SetActiveScene (SceneManager.GetSceneByName ("menuScene"));
			else
				SceneManager.LoadSceneAsync ("menuScene");
		}
	}
}
