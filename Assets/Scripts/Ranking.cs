using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {
	public int brokenGlassNumber;
	public GameObject player;
	public Text rank1Text;
	public Text rank2Text;
	public Text rank3Text;
	public static int rank1;
	public static int rank2;
	public static int rank3;
	public Text glassLabel;

	// Use this for initialization
	void Start () {
		rank1Text.text = rank1.ToString();
		rank2Text.text = rank2.ToString();
		rank3Text.text = rank3.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		//ガラスの枚数を更新
		glassLabel.text = brokenGlassNumber.ToString();

		//ゲームオーバー時にランキングを更新
		if(player.transform.position.y < -10.0f || player.transform.position.y >10.0f || 
			player.transform.position.x < -10.0f || player.transform.position.x >10.0f){
			RankingUpdate ();
		}
	}

	public void RankingUpdate(){
		if(rank1 < brokenGlassNumber){
			rank3 = rank2;
			rank2 = rank1;
			rank1 = brokenGlassNumber;
		}else if(rank2 < brokenGlassNumber && brokenGlassNumber < rank1){
			rank3 = rank2;
			rank2 = brokenGlassNumber;
		}else if(rank3 < brokenGlassNumber && brokenGlassNumber < rank2){
			rank3 = brokenGlassNumber;
		}
		rank1Text.text = rank1.ToString();
		rank2Text.text = rank2.ToString();
		rank3Text.text = rank3.ToString();
	}
}
