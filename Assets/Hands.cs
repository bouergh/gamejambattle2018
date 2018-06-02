
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hands : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnCollisionEnter(Collision collision){

        Debug.Log("colliding with stuff");
        if (collision.gameObject.CompareTag("Obstacle") && GetComponentInParent<PlayerController>().grabbing)
        {
            GetComponentInParent<PlayerController>().Drag(collision.gameObject);
            Debug.Log("grabbed Obstacle");
        }
    }
}
