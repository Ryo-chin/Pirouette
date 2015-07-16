using UnityEngine;
using System.Collections;

public class StageInstantiate : MonoBehaviour {
	public GameObject[] Cylinder;
	public GameObject Glass;
	public float CylinderSpawnDistanece;
	public int SpawnNumber;
	public int GlassRatioPerCylinder;

	private GameObject instCylinder;
	private GameObject instGlass;
	public GameObject stage;
	private int instNumberC;
	private int instNumberG;
	public int propNumberC;
	//新しいステージ生成時に利用
	Vector3 instantiatedPos;
	//Cylinderを追加するタイミングを教える
	public int[] stageCylinderChangeNumber;

	// Use this for initialization
	void Start () {
		//初期位置 Vector3(0,0,0)を空Objで定義
		instCylinder = stage;

		//初期化
		instNumberC = 0;
		instNumberG = 0;

		 //Initial Cylinder
		for(int i=1;i<=SpawnNumber;i++){
			if (i < 10) {
				instNumberC = i;
				StageInst (instNumberC, instNumberG, 7);
			} else {
				instNumberC = i;
				StageInst (instNumberC, instNumberG, propNumberC);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		//生成したGlassの数に応じて生成するCylinderの種類を更新
		if(instantiatedPos.z - instCylinder.transform.position.z >= 10){
			instNumberC++;
			StageInst(instNumberC,instNumberG,propNumberC);
		}
	}

	//instNumberC,instNumberGを渡してステージを生成する関数
	void StageInst(int cylinderNumber,int glassNumber,int cylinderPropertyNumber){
		//新しいCylinderを生成
		instCylinder = (GameObject)Instantiate
			(
				Cylinder[Random.Range(0,cylinderPropertyNumber)],
				instCylinder.transform.position + new Vector3(0,0,CylinderSpawnDistanece), 
				Quaternion.Euler(new Vector3(0,0,Random.Range(-45,45)))
			);
		//条件を満たしているときのみ新しいGlassを生成
		if(cylinderNumber % GlassRatioPerCylinder == 0){
			instGlass = (GameObject)Instantiate(
				Glass,
				instCylinder.transform.position,
				transform.rotation);
			//新しく生成したGlassの親をStageにする
			instGlass.transform.parent = stage.gameObject.transform;
			//Glassをナンバリング
			glassNumber++;
			instGlass.name = "Glass_" + glassNumber;
			instNumberG = glassNumber;
		}
		//新しく生成したCylinderの親をStageにする
		instCylinder.transform.parent = stage.gameObject.transform;
		//Cylinderをナンバリング
		instCylinder.name = "Cylinder_" + cylinderNumber;
		//生成時の位置を保存
		instantiatedPos = instCylinder.transform.position;
	}
}