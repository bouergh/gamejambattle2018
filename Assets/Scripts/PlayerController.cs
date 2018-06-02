using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public string xInput = "Horizontal";
	public string yInput = "Vertical";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement = new Vector3(Input.GetAxis(xInput), 0f, Input.GetAxis(yInput));
		GetComponent<Rigidbody>().velocity = speed*movement;
	}
}
