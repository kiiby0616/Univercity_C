using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class system : MonoBehaviour {
	public GameObject camera;
	public GameObject star;
	public GameObject haikei;
	public GameObject preT;
	public GameObject playerG;
	public GameObject coin;
	public GameObject coinPre;
	public GameObject beam;
	public GameObject cameraC;
	public Text stratT;
	public Text hisco;
	public static int hiscore = 0;
	public float cameraPFX = 30f;
	public float bai = 1;
	public Text speed;
	private float vel =0 ;
	private bool start = false;
	private bool miss ;
	public GameObject[] tama;
	public GameObject mawarutama;
	int score = 0;
	int scoreS = 500;
	int scoreMAWA = 600;
	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < 40; i++) {
			GameObject go = Instantiate (star) as GameObject;
			float ramX = Random.Range (-15f, 15f);
			float ramY = Random.Range (-10.0f, 10.0f);
			go.transform.parent = haikei.transform;
			go.transform.position = new Vector3 (ramX, ramY, 0);
		}for (int i = 0; i < 40; i++) {
			GameObject go = Instantiate (star) as GameObject;
			float ramX = Random.Range (15f, 45f);
			float ramY = Random.Range (-10.0f, 10.0f);
			go.transform.parent = haikei.transform;
			go.transform.position = new Vector3 (ramX, ramY, 0);
		}for (int i = 0; i < 40; i++) {
			GameObject go = Instantiate (star) as GameObject;
			float ramX = Random.Range (45f, 75f);
			float ramY = Random.Range (-10.0f, 10.0f);
			go.transform.parent = haikei.transform;
			go.transform.position = new Vector3 (ramX, ramY, 0);
		}
		stratT.text = "Are You Ready ?";
		speed.text = "速度:0"+"\n"+ "スコア:0";

	}

	// Update is called once per frame
	void Update () {
		Vector3 cameraP = camera.transform.position;
		player plaS = playerG.GetComponent < player> ();
		score = plaS.scoreP ();
		miss = plaS.missB ();
		if (cameraP.x > cameraPFX) {
			hichi (bai);
			tamaH (bai+4); 
			coinH (bai + 4);
			mwa (bai + 7);
			cameraPFX += 30;
			bai += 1;
		}
		if (Input.GetMouseButtonDown (0)) {
			if(vel==0){
				speed.text = "速度:"+vel+"\n"+ "スコア:"+0;
				start = true;
				stratT.text = "GO!!";
				Invoke ("Delaymethod", 1.5f);
				vel = 1;
			}
		}
		if (Input.GetMouseButton (1)) {
			if (start == true) {
				vel += 0.2f;
			}
		}
		if (score > hiscore) {
			hiscore = score;
		}
		if (start == true) {
			speed.text = "速度:" + ((int)vel + 1f)+"\n"+ "スコア:"+score;
		}
		if (miss == true) {
			stratT.text = "!MISS!";
			hisco.text = "スコア:"+score+"\n" + "ハイスコア:" + hiscore;
		}
		if (score > scoreS) {
			beamV ();
			scoreS += 300;
		}


	}

	void hichi(float x){
		for (int i = 0; i < 40; i++) {
			GameObject go = Instantiate (star) as GameObject;
			float ramX = Random.Range (45f+(30*x), 75f+(30*x));
			float ramY = Random.Range (-10.0f, 10.0f);
			go.transform.parent = haikei.transform;
			go.transform.position = new Vector3 (ramX, ramY, 0);
		}
	}
	void tamaH(float x){
		for (int i=0;i<10;i++){
		GameObject go = Instantiate(tama[Random.Range(0,9)])as GameObject;
		float ramX = Random.Range (45f+(30*x), 75f+(30*x));
		float ramY = Random.Range (-10.0f, 10.0f);
		go.transform.parent = preT.transform;
		go.transform.position = new Vector3 (ramX, ramY, 0);
		}
	}
	void Delaymethod(){
		stratT.text = "";
	}
	void coinH(float x){
		for (int i=0;i<5;i++){
			GameObject go = Instantiate(coin)as GameObject;
			float ramX = Random.Range (45f+(30*x), 75f+(30*x));
			float ramY = Random.Range (-10.0f, 10.0f);
			go.transform.parent = coinPre.transform;
			go.transform.position = new Vector3 (ramX, ramY, 0);
		}
	}
	void beamV(){
		GameObject go = Instantiate (beam)as GameObject;
		float ramY = Random.Range (-9.0f, 9.0f);
		go.transform.parent = cameraC.transform;
		go.transform.position = new Vector3 (cameraC.transform.position.x+18, ramY, 0);
	}
	void mwa(float x){
		for (int i=0;i<3;i++){
			GameObject go = Instantiate(mawarutama)as GameObject;
			float ramX = Random.Range (45f+(30*x), 75f+(30*x));
			float ramY = Random.Range (-10.0f, 10.0f);
			go.transform.parent = preT.transform;
			go.transform.position = new Vector3 (ramX, ramY, 0);
		}
	}



}
