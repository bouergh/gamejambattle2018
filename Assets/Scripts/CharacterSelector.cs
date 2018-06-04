using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {


	public PlayerController characterA;
	public Image buttonA;
	public PlayerController characterB;
	public Image buttonB;
	public PlayerController characterX;
	public Image buttonX;
	public PlayerController characterY;
	public Image buttonY;


	// Use this for initialization
	void Start () {
		//debug/editor instructions
		Debug.Log("Press A to player "+characterA.gameObject.name);
		Debug.Log("Press B to player "+characterB.gameObject.name);
		Debug.Log("Press X to player "+characterX.gameObject.name);
		Debug.Log("Press Y to player "+characterY.gameObject.name);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
