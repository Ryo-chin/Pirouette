using UnityEngine;
using System.Collections;

public class DontDestroySound : MonoBehaviour {
	public static int onof;
	void Awake(){
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
			onof++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
