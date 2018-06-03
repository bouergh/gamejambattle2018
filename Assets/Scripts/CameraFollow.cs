using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject robot;
	private Vector3 diff;
	// Use this for initialization
	void Start () {
		diff = transform.position - robot.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(robot){ //throw less error when he's dead
			Vector3 newPos = robot.transform.position + diff;
			transform.position = new Vector3(newPos.x, Mathf.Min(newPos.y,transform.position.y), Mathf.Min(newPos.z,transform.position.z)) ;
		}
	}
}
