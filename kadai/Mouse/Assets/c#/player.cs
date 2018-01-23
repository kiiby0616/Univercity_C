using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
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

	// Use this for initialization
	void Start () {
		rd = gameObject.GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
		posST = gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		pos = gameObject.transform.position;
		rote = gameObject.transform.localEulerAngles;
		speed = new Vector3 (Xspeed, 0, 0);
		transform.position += speed * Time.deltaTime;
		if(Input.GetMouseButton(0))
		{
			if (control == true) {
				rd.velocity = Vector2.up * UP;
				if (Xspeed == 0) {
					Xspeed = 10;
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
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene (0);
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
			miss = true;
			control = false;
			Xspeed = 0;
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
	public int scoreP(){
		return score;
	}
	public bool missB (){
		return this.miss;
	}

}
