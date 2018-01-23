using UnityEngine;
using System.Collections;

public class tama : MonoBehaviour {
	private SpriteRenderer spR;
	float red =1.0f;
	float green = 0f;
	float blue = 0f;
	float alpha = 1.0f;
	float time = 0f;
	bool colB =false;
	public bool moveU =false;
	public bool moveD = false;
	public bool moveR =false;
	public bool moveL = false;
	Vector3 move;
	GameObject player;
	float kyori;
	public bool moveB = false;

	// Use this for initialization
	void Start () {
		spR = GetComponent<SpriteRenderer> ();
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		spR.color = new Color (red, green, blue, alpha);


		transform.position += move * Time.deltaTime;
		kyori = Mathf.Abs (transform.position.x - player.transform.position.x);
		if (kyori < 25) {
			if (moveU == true) {
				move.y = 1.5f;
			}
			if (moveD == true) {
				move.y = -1.5f;
			}
			if (moveR == true) {
				move.x = +1.5f;
			}
			if (moveL == true) {
				move.x = -1.5f;
			}
		}
}
}