using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class subgameP : MonoBehaviour {
	float time=10;
	Rigidbody2D rd;
	bool firstC=false;
	int power = 0;
	Vector3 speed;
	bool ten = false;

	private Vector3 mouseP;
	private Vector3 mousePS;
	public Text timeT;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		timeT.text = "左クリック連打せよ！";

	}
	
	// Update is called once per frame
	void Update () {
		speed = new Vector3 (power, 0, 0);
		//座標取得
		mousePS = Input.mousePosition;

		float playerPx = transform.position.x;
		float playerPy = transform.position.y;
		//角度計算
		float dx=mouseP.x-playerPx;
		float dy = mouseP.y - playerPy;
		float radian = Mathf.Atan2 (dy,dx);
		float kakudo = radian * Mathf.Rad2Deg;
		//2点間の距離
		float kyori = Mathf.Sqrt((dx*dx)+(dy*dy));

		if (Input.GetMouseButtonDown (0)) {
			firstC = true;
			renda ();

		}
		if (firstC == true) {
			time -= Time.deltaTime;
			timeT.text = (Mathf.Floor(time*100)).ToString();
			Debug.Log (power);


			if (time <= 0) {
				time = 0;
				ten = true;
				rd.gravityScale = 1;
				transform.position += speed * Time.deltaTime;
				timeT.text ="GO!!";
				Invoke ("des", 1f);
			}
		}
			
	}
	void renda(){
		if (time > 0) {
			power += 1;
		}
	}
	void des(){
		Destroy (timeT);
	}
}
