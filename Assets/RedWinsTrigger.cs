using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedWinsTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Robot")){
			SceneManager.LoadScene("RedWins");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
