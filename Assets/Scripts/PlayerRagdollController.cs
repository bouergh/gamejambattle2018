using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollController : MonoBehaviour {

	public Rigidbody head;



	public float speed = 10f;
	public string xInput = "Horizontal";
	public string xInputJoy = "HorizontalJoy1";
	public string yInput = "Vertical";
	public string yInputJoy = "VerticalJoy1";
	public float minMagnitude = 0.01f; //if movement magnitude on joy is inferior to this we go for arrows
	public string grabButton = "Grab1";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement = new Vector3(Input.GetAxisRaw(xInputJoy), 0f, Input.GetAxisRaw(yInputJoy));
		if(movement.magnitude < minMagnitude)
			movement = new Vector3(Input.GetAxisRaw(xInput), 0f, Input.GetAxisRaw(yInput));
		head.velocity = speed*movement;
	}
}
