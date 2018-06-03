using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hands : MonoBehaviour {

	public Rigidbody rbToFollow;
	Vector3 initialD;
	float initialY;

	// Use this for initialization
	void Start () {
		rbToFollow = transform.parent.Find("Bip001 Head").GetComponent<Rigidbody>();
		initialY = transform.localPosition.y;
		initialD = transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Vector3 pos = rbToFollow.position+initialD;
		//transform.localPosition = new Vector3(pos.x, initialY, pos.z);
	}

	 void OnTriggerStay(Collider collision){
		 Debug.Log("hands collides");
		GetComponentInParent<PlayerController>().Drag(collision);
	 }
}
