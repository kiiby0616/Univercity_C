using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {
	public string load;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onCl(){
		SceneManager.LoadScene (load);
	}
}
