using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerP = player.transform.position;
		transform.position = new Vector3 (playerP.x+12, transform.position.y, transform.position.z);
	}
}
