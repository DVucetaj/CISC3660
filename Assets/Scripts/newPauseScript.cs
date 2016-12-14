using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newPauseScript : MonoBehaviour {


	public Button resumeButton;
	public GameObject pauseMenu, dialBox;
	public GameObject dieMenu;
	public bool isPaused = false;


	public void Update(){

		if (!dialBox.activeInHierarchy && !dieMenu.activeInHierarchy) {
			if (Input.GetKeyUp (KeyCode.Escape)) {
				pauseGame ();	
			}
			checkPause ();
		}

	}

	public void pauseGame(){
		isPaused = !isPaused;
	}


	public void checkPause(){
		if(isPaused){
			pauseMenu.SetActive(true);
			Time.timeScale = 0.000f;
		}else{
			Time.timeScale = 1.00f;
			pauseMenu.SetActive(false);
		}

	}


	public void QuitGame(){
		Application.Quit ();
	}

}
