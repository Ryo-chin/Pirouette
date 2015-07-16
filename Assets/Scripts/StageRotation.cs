using UnityEngine;
using System.Collections;

public class StageRotation : MonoBehaviour {
	public float stageRotationSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0){
			if(Input.GetKey("right")){
				RightRotation();
			}
			if(Input.GetKey("left")){
				LeftRotation();
			}
		}	
	}

	public void RightRotation(){
		transform.Rotate(Vector3.forward* stageRotationSpeed);
	}

	public void LeftRotation(){
		transform.Rotate(-Vector3.forward * stageRotationSpeed);
	}
}
