using UnityEngine;
using System.Collections;

public class SoundOnOf : MonoBehaviour {
	DontDestroySound sceneLoad;
	public GameObject bgm;
	// Use this for initialization
	void Start () {
		sceneLoad = GetComponent<DontDestroySound>();
		if(DontDestroySound.onof == 0){
			bgm.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
