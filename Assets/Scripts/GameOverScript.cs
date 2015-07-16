using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	public GameObject player;
	public GameObject retryButton;
	public GameObject background;
	public GameObject pauseButton;
	public GameObject explosionEffect;
	public GameObject ranking;
	bool isInstExp = false;
	Ranking rankingScript;
	RetryScript retryScript;
	GameObject stage;

	// Use this for initialization
	void Start () {
		rankingScript = GetComponent<Ranking> ();
		retryScript = GetComponent<RetryScript> ();
		stage = GameObject.Find ("Stage");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y < -10.0f || player.transform.position.y >10.0f || 
			player.transform.position.x < -10.0f || player.transform.position.x >10.0f)
		{
			GameOverExlplosion();
			GameOverUI ();
		}
	}
	public void GameOverExlplosion(){
		player.SetActive (false);
		if(isInstExp == false){
			Instantiate (explosionEffect,player.gameObject.transform.position,Quaternion.identity);
			isInstExp = true;
		}
	}
	public void GameOverUI(){
		pauseButton.SetActive(false);
		background.SetActive(true);
		retryButton.SetActive(true);
		if (Input.GetKey("r")) {
			retryScript.SceneLoad ();
		}
		rankingScript.RankingUpdate ();
		ranking.SetActive(true);
		stage.GetComponent<StageMove>().enabled = false;
	}
}
