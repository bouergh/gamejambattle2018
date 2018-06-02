using System.Collections;
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

		 foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

		 Debug.Log("colliding with stuff");
		 if(collision.gameObject.CompareTag("Obstacle") && GetComponentInParent<PlayerController>().grabbing){
			 GetComponentInParent<PlayerController>().Drag(collision.gameObject);
			 Debug.Log("grabbed Obstacle");
		 }
	 }
}
=======
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

		 foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

		 Debug.Log("colliding with stuff");
		 if(collision.gameObject.CompareTag("Obstacle") && GetComponentInParent<PlayerController>().grabbing){
			 GetComponentInParent<PlayerController>().Drag(collision.gameObject);
			 Debug.Log("grabbed Obstacle");
		 }
	 }
}
>>>>>>> 20c9192314dce194c8dbe7e618e786bee558dfe8
