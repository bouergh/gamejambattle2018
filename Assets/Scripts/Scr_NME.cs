/************************************
Owner : Logan Lesage
Date : 06/04/2018
************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_NME : MonoBehaviour {
	public int hp = 1;
	public float vitesse = 1f;
	public float impulsionSaut = 10f;


	private Rigidbody2D rb;
	private Transform tr;

	public bool isShielded = false;



	// Use this for initialization

	void Start () {


		rb = this.GetComponent<Rigidbody2D> ();
		tr = this.transform;
	}

	// Update is called once per frame
	void Update () {
		Vector3 entree = Vector3.zero;;
		entree.x = Input.GetAxis("Horizontal");


		if (entree.x <= 0.2f && entree.x >= -0.2f) {
			entree.x = 0;
			entree.x *= vitesse;
		}

		if(Input.GetButtonDown("Jump")){
				entree.y = impulsionSaut;
			}

		else {
			entree.y = rb.velocity.y;
		}
		/*if (entree.y > 0)
			onGround = false;*/
		/*//Facing
		Vector3 tempScale = Vector3.one;
		tempScale.x = Mathf.Sign (entree.x);
		tr.localScale = tempScale;*/

		rb.velocity = entree;

		if (hp <=0){
			Destroy (this.gameObject);
		}



	}

	// No dammage if isShieled
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("bullet")) {
			if (isShielded == false) {
				hp--; 
			}
		}
	}


	// Functions

}