using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		//StartCoroutine(HideMessage());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// IEnumerator HideMessage(){
	// 	yield return new WaitForSeconds(3f);
	// 	text.text = "";
	// }

	// public void GreenWins(){
	// 	text.text = "GG Green";
	// }

	// public void BlueWins(){
	// 	text.text = "GG Blue";
	// }
}
