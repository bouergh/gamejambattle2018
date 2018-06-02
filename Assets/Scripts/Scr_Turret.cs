/************************************
Owner : Logan Lesage
Date : 06/04/2018
************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Turret : MonoBehaviour {
	public GameObject bullet; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")){
			Instantiate (bullet, transform.position,transform.rotation);
		}
	}
}
