﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerStay(Collider collision){
		 Debug.Log("hands collides");
		GetComponentInParent<PlayerController>().Drag(collision);
	 }
}
