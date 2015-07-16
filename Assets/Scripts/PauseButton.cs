using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	public GameObject pausePanel;
	public GameObject pauseButton;
	public GameObject resumeButton;
	public GameObject pauseText;
	public GameObject retryButton;

	// Use this for initialization
	void Start () {
		resumeButton.SetActive (false);
		pausePanel.SetActive (false);
		pauseText.SetActive(false);
		retryButton.SetActive (false);
		pauseButton.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t")) {

			if (Time.timeScale == 0) {
				OnPause ();
			} else {
				OnResume ();
			}

		}
	}

	public void OnPause(){
		Time.timeScale = 0;
		pauseButton.SetActive (false);
		pausePanel.SetActive (true);
		resumeButton.SetActive (true);
		pauseText.SetActive(true);
		retryButton.SetActive (true);
	}
	public void OnResume(){
		Time.timeScale = 1;
		resumeButton.SetActive (false);
		pausePanel.SetActive (false);
		pauseText.SetActive(false);
		retryButton.SetActive (false);
		pauseButton.SetActive (true);
	}
}
