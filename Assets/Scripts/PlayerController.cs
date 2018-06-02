﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	
	//clavier
	public string xInput = "Horizontal", yInput = "Vertical", xLook = "HorizontalLook", yLook = "VerticalLook";
	//manette
	public string xInputJoy = "HorizontalJoy1", yInputJoy = "VerticalJoy1", xLookJoy = "HorizontalLookJoy1", yLookJoy = "VerticalLookJoy1";
	public string grab = "Grab1", grabJoy = "GrabJoy1";
	public float minMagnitude = 0.01f; //if movement magnitude on joy is inferior to this we go for arrows
	public bool grabbing;
	public Rigidbody grabbedObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();
		Rotate();
	}
	void Update(){
		Grab();
	}

	void Move(){
		Vector3 movement = new Vector3(Input.GetAxisRaw(xInputJoy), 0f, Input.GetAxisRaw(yInputJoy));
		if(movement.magnitude < minMagnitude)
			movement = new Vector3(Input.GetAxisRaw(xInput), 0f, Input.GetAxisRaw(yInput));
		GetComponent<Rigidbody>().velocity = speed*movement;
		if(grabbedObject) grabbedObject.velocity = speed*movement;
	}
	void Rotate(){
		//player rotation
		Vector3 rot = new Vector3(Input.GetAxisRaw(xLook), 0f, Input.GetAxisRaw(yLook));
		if(rot.magnitude < minMagnitude)
			rot = new Vector3(Input.GetAxisRaw(xLookJoy), 0f, Input.GetAxisRaw(yLookJoy));
		transform.LookAt(transform.position+10f*rot);
	}

	void Grab(){
		//only joy for now
		if(Input.GetButtonDown(grabJoy)){
			grabbing = true;
		}
		if(Input.GetButtonUp(grabJoy)){
			grabbing = false;
			if(grabbedObject){
				grabbedObject = null;
			}
		}
	}

	public void Drag(GameObject go){
		grabbedObject = go.GetComponent<Rigidbody>();
	}

	
	 void OnCollisionEnter(Collision collision){

		 Debug.Log("colliding with stuff");
		 if(collision.gameObject.CompareTag("Obstacle") && grabbing && !grabbedObject){
			 grabbedObject = collision.rigidbody;
			 Debug.Log("grabbed Obstacle");
		 }
	 }

}
