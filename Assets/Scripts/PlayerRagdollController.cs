
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollController : MonoBehaviour {

	public Rigidbody head, leftHand, rightHand, pelvis;


	public float speed = 10f, zFix = 10f, moveForce = 10f;
	//clavier
	public string xInput = "Horizontal", yInput = "Vertical", xLook = "HorizontalLook", yLook = "VerticalLook";
	//manette
	public string xInputJoy = "HorizontalJoy1", yInputJoy = "VerticalJoy1", xLookJoy = "HorizontalLookJoy1", yLookJoy = "VerticalLookJoy2";
	public float minMagnitude = 0.01f; //if movement magnitude on joy is inferior to this we go for arrows
	public string grabButton = "Grab1";
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		FixZ();
		Move();
		//Rotation();
		//Grab();
	}

	void FixZ(){
		head.AddForce(zFix*Vector3.up-Physics.gravity, ForceMode.Acceleration);
		pelvis.AddForce(zFix*Vector3.down,ForceMode.Acceleration);
	}
	void Move(){
		//player position
		Vector3 movement = new Vector3(Input.GetAxisRaw(xInputJoy), 0f, Input.GetAxisRaw(yInputJoy));
		if(movement.magnitude < minMagnitude)
			movement = new Vector3(Input.GetAxisRaw(xInput), 0f, Input.GetAxisRaw(yInput));
		head.velocity = speed*movement;
		//pelvis.AddForce(moveForce*movement, ForceMode.Acceleration);
	}

	void Rotation(){
		//player rotation
		Vector3 rot = new Vector3(Input.GetAxisRaw(xLook), 0f, Input.GetAxisRaw(yLook));
		if(rot.magnitude < minMagnitude)
			rot = new Vector3(Input.GetAxisRaw(xLookJoy), 0f, Input.GetAxisRaw(yLookJoy));
		head.transform.LookAt(head.transform.position+10f*rot);
		head.transform.rotation = new Quaternion( 0f, head.transform.rotation.y, 0f, head.transform.rotation.w); 
	}

	void Grab(){

	}

}
