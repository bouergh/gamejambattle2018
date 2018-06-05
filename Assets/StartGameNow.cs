using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameNow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0;i < 8; i++) {
				if(Input.GetKeyDown("joystick "+(i+1)+" button 7")){
					SceneManager.LoadScene("Logan_Gym");
			}
		}
	}
}
