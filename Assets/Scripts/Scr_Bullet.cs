/************************************
Owner : Logan Lesage
Date : 06/04/2018
************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Bullet : MonoBehaviour {
	public float speed = 10f;
	private Transform tr;
	public GameObject bullet;


	// Use this for initialization
	void Start () {
		tr = this.transform;
		
	}
	
	void Update () {
		tr.Translate (speed * Time.deltaTime, 0f, 0f, Space.World);
	}
		

	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}


}

