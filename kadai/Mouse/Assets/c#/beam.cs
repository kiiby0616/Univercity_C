using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {
	public GameObject beamT;
	public GameObject effect;
	public GameObject effectP;
	private Vector3 speed;
	private Vector3 posi;
	// Use this for initialization
	void Start () {
		Invoke ("effe", 2.5f);
		Invoke ("nobasu", 5f);
		Invoke ("tidimu", 13f);
		Invoke ("death", 15f);
		posi = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		pos ();


	}
	void pos(){
		speed = new Vector3 (-1f, 0, 0);
		transform.position += speed * Time.deltaTime;
		if (transform.localPosition.x < posi.x - 2) {
			transform.localPosition = new Vector3 (posi.x - 2, posi.y, posi.z);
		}
	}

	void effe(){
		
		GameObject ef = Instantiate (effect)as GameObject;
		ef.transform.parent = gameObject.transform;
		ef.transform.localPosition = new Vector3 (-3.3f, 0, 0);
		effectP = ef;
	}

	void nobasu(){
		beamT.transform.localScale = new Vector3 (20, 1, 1);
		Destroy (effectP);
	} 
	void tidimu(){
		beamT.transform.localScale = new Vector3 (1,1,1);
	}
	void death(){
		Destroy (gameObject);
	}

	public bool anim(){
		return true;
	}
}
