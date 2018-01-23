using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
	private SpriteRenderer spR;
	float red =1.0f;
	float green = 1.0f;
	float blue = 0f;
	float alpha = 1.0f;
	float time = 0f;
	// Use this for initialization
	void Start () {
		spR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		spR.color = new Color (red, green, blue, alpha);
	}
}
