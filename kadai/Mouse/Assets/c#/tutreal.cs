using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class tutreal : MonoBehaviour {
	public Vector3 speed;
	public float Xspeed = 0;
	public float UP = 5;
	private Rigidbody2D rd;
	Animator anim;
	private Vector3 pos;
	private Vector3 rote;
	private Vector3 posST;
	private bool control = true;
	private bool onmouse;
	bool miss = false;
	public GameObject systemO;
	int score = 0;
	int coinP = 0;
	private bool hidan = false;


	public Text tut;
	bool tutre = false;

	public GameObject star;
	public GameObject haikei;
	public float bai = 1;
	public GameObject camera;
	public float cameraPFX = 30f;

	bool end = false;
	// Use this for initialization
	void Start () {
		rd = gameObject.GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
		posST = gameObject.transform.position;

		tut.text ="左クリック！";
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
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraP = camera.transform.position;

		if (cameraP.x > cameraPFX) {
			hichi (bai);

			cameraPFX += 30;
			bai += 1;
		}

		pos = gameObject.transform.position;
		rote = gameObject.transform.localEulerAngles;
		speed = new Vector3 (Xspeed, 0, 0);
		transform.position += speed * Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && tutre==false) {
			tut.text = "";
			Xspeed = 10;

		}
		if (gameObject.transform.position.y < -4  && tutre==false) {
			tut.text = "左クリックで上昇";
			Xspeed = 0;
			rd.isKinematic = true;

			if(Input.GetMouseButtonDown(0)){
				tutre = true;
				rd.isKinematic = false;
				tut.text ="";
			}
		}
		if (tutre == true) {
			
			sousa ();
		}
		if (gameObject.transform.position.x > 30&&gameObject.transform.position.x < 60) {
			tut.text = "上昇しするとミス";
		}
		if (gameObject.transform.position.x > 60&&gameObject.transform.position.x < 80) {
			tut.text = "";
		}
		if (gameObject.transform.position.x > 80&&gameObject.transform.position.x < 130) {
			tut.text = "赤い玉はミス\n黄色いコインはポイント";
		}
		if (gameObject.transform.position.x > 130 &&gameObject.transform.position.x < 150) {
			tut.text = "";
		}
		if (gameObject.transform.position.x > 150 ) {
			tut.text = "右クリックでスピードアップ\nチュートリアルは以上です\n右上のボタンからやめてください";
			end = true;
		}
		Debug.Log (speed);
	}
	void sousa(){
		pos = gameObject.transform.position;
		rote = gameObject.transform.localEulerAngles;
		speed = new Vector3 (Xspeed, 0, 0);
		transform.position += speed * Time.deltaTime;
		if(Input.GetMouseButton(0))
		{
			if (control == true) {
				rd.velocity = Vector2.up * UP;
				if (Xspeed == 0) {
					Xspeed = 6.5f;
					anim.SetBool ("left", true);
					onmouse = true;

				}
				onmouse = true;
			}

			anim.SetBool ("UP", true);
		}if (Input.GetMouseButtonUp (0)) {
			if (control == true) {
				anim.SetBool ("UP", false);
				onmouse = false;
			}
		}

		if (Input.GetMouseButton (1)) {
			if (control == true) {
				if (Xspeed != 0) {
					Xspeed = Xspeed + 0.05f;
				}
			}
		}

		if (pos.y > 11) {
			control = false;
		}
		if (onmouse == true) {
			if (Xspeed != 0) {
				if (rote.z < 320) {
					transform.Rotate (new Vector3 (0, 0, 8));
				}
			}
		}if (onmouse == false) {

			if (Xspeed != 0) {
				if (rote.z> 210) {
					transform.Rotate (new Vector3 (0, 0, -5));
				}
			}
		}
		anim.SetBool ("miss", miss);
		if (miss == true) {
			if (Input.GetMouseButtonDown (0)&& end != true) {
				SceneManager.LoadScene (2);
			}

		}
		if (hidan == true) {
			Xspeed = 0;
		}
		float kyori = Mathf.Abs (posST.x - pos.x);
		score = (int)kyori+coinP;
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "miss") {
			if (end == false) {
				miss = true;
				control = false;
				Xspeed = 0;
				tut.text = "まさかチュートリアル\nでミスするとは";
			}if (end == true) {
				miss = true;
				control = false;
				Xspeed = 0;

			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "tama") {
			control = false;
			hidan = true;
		}if (col.gameObject.tag == "coin") {
			coinP += 25;
			Destroy (col.gameObject);
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
}
