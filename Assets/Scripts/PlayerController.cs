using System.Collections;
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
	public bool grabbing;
	public Rigidbody grabbedObject;
	public Transform grabbedObjectParent;
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
		//if(grabbedObject) grabbedObject.velocity = speed*movement;
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
		if(Input.GetButtonDown(grabJoy) || Input.GetButtonDown(grab)){
			grabbing = true;
		}
		if(Input.GetButtonUp(grabJoy) || Input.GetButtonUp(grab)){
			grabbing = false;
			if(grabbedObject){
				grabbedObject.transform.parent = grabbedObjectParent;
				grabbedObject.isKinematic = false;
				grabbedObject.AddForce(transform.forward*dropForce, ForceMode.Impulse);
				grabbedObject = null;
			}
		}
	}

	public void Drag(Collider collision){
		if(collision.gameObject.CompareTag("Obstacle") && grabbing && !grabbedObject){
			 grabbedObject = collision.GetComponent<Rigidbody>();
			 grabbedObjectParent = grabbedObject.transform.parent;
			 grabbedObject.transform.parent = transform.Find("Hands");
			 grabbedObject.isKinematic = true;
		 }
	}

}
