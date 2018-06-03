using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simulator : MonoBehaviour 
{

	public float myTime = 1;
	private float i = 0; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		i += Time.deltaTime; 

		if (i > myTime) 
		{

			BroadcastMessage ("onPickup"); 

			i = 0;
		}
	}
}
