using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "ハイスコア:"+ system.hiscore;
	}
}
