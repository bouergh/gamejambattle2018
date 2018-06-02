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
		transform.position = robot.transform.position + diff;
	}
}
