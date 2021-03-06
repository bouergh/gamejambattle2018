﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10f, dropForce = 10f;
	
	//clavier
	public string xInput = "Horizontal", yInput = "Vertical", xLook = "HorizontalLook", yLook = "VerticalLook";
	//manette
	public string xInputJoy = "HorizontalJoy1", yInputJoy = "VerticalJoy1", xLookJoy = "HorizontalLookJoy1", yLookJoy = "VerticalLookJoy1";
	public string grab = "Grab1", grabJoy = "GrabJoy1";
	public float minMagnitude = 0.01f; //if movement magnitude on joy is inferior to this we go for arrows
	public bool grabbing = false;
	public Rigidbody grabbedObject;
	public Transform grabbedObjectParent;
	public Rigidbody rb;
	private Transform hands;

	public float handDistance = 1.5f;

	private float initYAngle;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		if(!rb){
			rb = transform.Find("Bip001 Head").GetComponent<Rigidbody>();
		}
		hands = transform.Find("Hands");
		initYAngle = transform.eulerAngles.y;


		//zeroing charactercontrol joystick
		xInputJoy = "";
		yInputJoy = "";
		xLookJoy = "";
		yLookJoy = "";
		grabJoy = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(xInputJoy != ""){ //quick fix with zeroing
			Move();
			Rotate();
			Grab();

		}
	}
	void Update(){
		
	}

	void Move(){
		Vector3 movement = new Vector3(Input.GetAxisRaw(xInputJoy), 0f, Input.GetAxisRaw(yInputJoy));
		if(movement.magnitude < minMagnitude)
			movement = new Vector3(Input.GetAxisRaw(xInput), 0f, Input.GetAxisRaw(yInput));
		rb.velocity = speed*movement;
		//if(grabbedObject) grabbedObject.velocity = speed*movement;
	}
	void Rotate(){
		//player rotation joy
		
			float x = Input.GetAxisRaw(xLookJoy);
			float y = Input.GetAxisRaw(yLookJoy);

			Vector3 rotDir = new Vector3(x, 0f, y);
		//or with keyboard
		if(rotDir.magnitude < minMagnitude){
			x = Input.GetAxisRaw(xLook);
			y = Input.GetAxisRaw(yLook);
			rotDir = new Vector3(x, 0f,y);
		}
		if(rotDir.magnitude > minMagnitude)
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, initYAngle + Mathf.Atan2(1000f*x, 1000f*y) * Mathf.Rad2Deg, transform.eulerAngles.z);

		//if(rotDir.magnitude > minMagnitude) transform.LookAt(rotDir);
		//if(rot.magnitude > minMagnitude) rb.rotation = headRotInit*Quaternion.LookRotation(rb.transform.position +10f*rot, Vector3.forward);
		}


	void Grab(){
		//only joy for now
		if(Input.GetButtonDown(grabJoy) || Input.GetButtonDown(grab)){
			grabbing = true;
		}
		if(Input.GetButtonUp(grabJoy) || Input.GetButtonUp(grab)){
			grabbing = false;

			if(grabbedObject){
				grabbedObject.transform.parent = grabbedObjectParent;
				grabbedObject.isKinematic = false;
				grabbedObject.gameObject.layer = LayerMask.NameToLayer("Obstacle");
				//grabbedObject.freezeRotation = false;
				grabbedObject.AddForce(hands.transform.forward*dropForce, ForceMode.Impulse);
				Destroy(grabbedObject.GetComponent<SpringJoint>());
				grabbedObject = null;
			}

		}
	}

	public void Drop(){
		grabbing = false;
			if(grabbedObject){
				grabbedObject.transform.parent = grabbedObjectParent;
				grabbedObject.isKinematic = false;
				grabbedObject.gameObject.layer = LayerMask.NameToLayer("Obstacle");
				//grabbedObject.freezeRotation = false;
				//grabbedObject.AddForce(hands.transform.forward*dropForce, ForceMode.Impulse);
				Destroy(grabbedObject.GetComponent<SpringJoint>());
				grabbedObject = null;
			}
	}

	public void Drag(Collider collision){
		if(collision.gameObject.CompareTag("Obstacle") && grabbing && !grabbedObject){
			grabbedObject = collision.GetComponent<Rigidbody>();
			// //old
			grabbedObjectParent = grabbedObject.transform.parent;
			//grabbedObject.transform.position = hands.position + handDistance*hands.forward;
			//grabbedObject.transform.parent = hands;
			//grabbedObject.isKinematic = true;
			//grabbedObject.freezeRotation = true;

			grabbedObject.gameObject.layer = LayerMask.NameToLayer("ObstacleNoCollide");
			//config du springjoint
			SpringJoint hj = grabbedObject.gameObject.AddComponent(typeof(SpringJoint)) as SpringJoint;
			hj.connectedBody = rb;
			hj.enableCollision = false;
			hj.spring = 100;
			hj.damper = 0.8f;
			hj.tolerance = 0.001f;
			hj.massScale = 100f;
			hj.connectedMassScale = 100f;
		 }
	}

	public void AssociateController(int controllerNumber){
		xInputJoy = "HorizontalJoy"+controllerNumber;
		yInputJoy = "VerticalJoy"+controllerNumber;
		xLookJoy = "HorizontalLookJoy"+controllerNumber;
		yLookJoy = "VerticalLookJoy"+controllerNumber;
		grabJoy = "GrabJoy"+controllerNumber;
	}
}
