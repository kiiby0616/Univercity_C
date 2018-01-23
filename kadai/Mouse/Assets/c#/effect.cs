using UnityEngine;
using System.Collections;

public class effect : MonoBehaviour {

	public beam beamB;
	Animator ani;
	private SpriteRenderer spR;
	float red =1.0f;
	float green = 1.0f;
	float blue = 1.0f;
	float alpha = 0.5f;
	private bool anim = false;
	// Use this for initialization
	void Start () {
		spR = GetComponent<SpriteRenderer> ();
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		spR.color = new Color (red, green, blue, alpha);


	}
}
