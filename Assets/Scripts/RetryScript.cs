using UnityEngine;
using System.Collections;

public class RetryScript : MonoBehaviour {
	GameObject stage;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SceneLoad () {
		Time.timeScale = 1;
		stage = GameObject.Find ("Stage");
		stage.GetComponent<StageMove> ().enabled = true;
		Application.LoadLevel("Main");
	}
}
