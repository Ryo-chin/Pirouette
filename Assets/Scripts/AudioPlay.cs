using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = gameObject.GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void Update () {	
	}

	void OnCollisionEnter(Collision col ){
		if (col.gameObject.tag == "Player") {
			audio.Play ();
		}
	}
}
