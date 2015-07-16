using UnityEngine;
using System.Collections;

public class SwordRotation : MonoBehaviour {
	public float swordRotSpeed = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (transform.forward * swordRotSpeed * Time.deltaTime);
	}
}
