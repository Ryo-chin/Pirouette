using UnityEngine;
using System.Collections;

public class GameLoadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("space")){
			LoadMain();
		}
	}

	public void LoadMain(){
		Application.LoadLevel("Main");
	}
}
