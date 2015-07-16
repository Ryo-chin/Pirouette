using UnityEngine;
using System.Collections;

public class StageMove : MonoBehaviour {
	public float Speed = 20f;
	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		// 前方へ移動する
		transform.position -= transform.forward * Time.deltaTime * Speed;
	}
}
