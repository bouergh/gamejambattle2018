using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour {
    
	public float speed = 3f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Debug.Log(transform.position);
		//transform.position -= 0.1f*Vector3.forward;
		GetComponent<Rigidbody>().velocity = -speed*Vector3.forward;
	}
}
