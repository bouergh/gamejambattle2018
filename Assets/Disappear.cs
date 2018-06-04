using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {

	private float counter = 0f;
	public float timer = 5f;
	// Use this for initialization
	void Start () {
		counter = 0f;
	}
	
	// Update is called once per frame
	 void Update () {
		counter += Time.deltaTime;
		if(counter >= timer){
			Destroy(gameObject);
		}
	}
}
