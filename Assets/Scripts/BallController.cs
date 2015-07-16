using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallController : MonoBehaviour {
	public GameObject glassBreakEffct;
	GameObject glassBreakEffctInstnce;
	public GameObject spark;
	GameObject sparkInstance;
	public ParticleSystem speedEffect;
	public Text glassLabel;
	public Camera mainCamera;
	private bool isRunningSpeedUp;
	public float cylinderSpeed;
	public float upSpeed;
	public float downSpeed;

	BreakGlass g;
	Ranking ranking;
	GameOverScript gameOverScript;
	Rigidbody rigidBody;
	StageInstantiate staInst;

	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
		GameObject gm = GameObject.Find ("GameManeger");
		gameOverScript = gm.GetComponent<GameOverScript> (); 
		ranking = gm.GetComponent<Ranking>();
		isRunningSpeedUp = false;
		//Cylinderの種類を変更するGlassの枚数を取得する
		GameObject sg = GameObject.Find ("StageGenerator");
		staInst = sg.GetComponent<StageInstantiate>();
	}

	void Update () {
		if (isRunningSpeedUp) {
			StartCoroutine (SpeedUp());
		}
	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag=="Glass"){
			ranking.brokenGlassNumber += 1;
		}

		if(col.gameObject.tag == "Cylinder"){
			rigidBody.velocity += mainCamera.transform.forward * Time.deltaTime * cylinderSpeed;
//			rigidBody.AddForce(rigidBody.velocity * cylinderSpeed);
			sparkInstance = Instantiate (spark, transform.position, Quaternion.identity) as GameObject;
			sparkInstance.transform.parent = gameObject.transform;
		}

		if(col.gameObject.tag == "SpeedUp"){
			isRunningSpeedUp = true;
			if(isRunningSpeedUp){
				StartCoroutine (SpeedEffectChange (speedEffect));
				StartCoroutine (SpeedUp());
				isRunningSpeedUp = false;
			}
		}

		if(col.gameObject.tag == "Enemy"){
			gameOverScript.GameOverExlplosion ();
			gameOverScript.GameOverUI ();
		}

		if(col.gameObject.GetComponent<BreakGlass>()!=null){
			g = col.gameObject.GetComponent<BreakGlass>();
//			rigidbody.velocity = vel * g.SlowdownCoefficient;
			
			if(g.BreakByVelocity){
				if(col.relativeVelocity.magnitude >= g.BreakVelocity){
					col.gameObject.GetComponent<BreakGlass>().BreakIt();
					glassBreakEffctInstnce = Instantiate (glassBreakEffct,transform.position,Quaternion.identity) as GameObject;
					glassBreakEffctInstnce.transform.parent = gameObject.transform;
					return;
				}
			}
			
			if(g.BreakByImpulse){
				if(col.relativeVelocity.magnitude * GetComponent<Rigidbody>().mass >= g.BreakImpulse){
					col.gameObject.GetComponent<BreakGlass>().BreakIt();
					glassBreakEffctInstnce = Instantiate (glassBreakEffct,transform.position,Quaternion.identity) as GameObject;
					glassBreakEffctInstnce.transform.parent = gameObject.transform;
					return;	
				}
			}
		}
	}
		
	IEnumerator SpeedEffectChange(ParticleSystem parSys)
	{
		parSys.emissionRate = 800.0f ;
		yield return new WaitForSeconds (2.0f);
		parSys.emissionRate = 90.0f ;
	}

	IEnumerator SpeedUp(){
		float speedUpTime = 0;
		while (speedUpTime < 2.0f) {
			speedUpTime += Time.deltaTime;
			rigidBody.velocity += mainCamera.transform.forward * Time.deltaTime * upSpeed;
			yield return null;
		}
	}
}
