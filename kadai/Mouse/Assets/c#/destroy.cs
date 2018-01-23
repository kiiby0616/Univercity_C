using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
	public float posX = 0;
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		posX =  gameObject.transform.position.x-player.transform.position.x ;
		if (posX < -8) {
			Destroy (gameObject);
		}

	}
}
