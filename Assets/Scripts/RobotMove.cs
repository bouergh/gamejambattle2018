using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour {
    
	public float speed = 3f;
	public float dodgeSpeed = 10f;
	public float dodgeDistance = 9f;
	public float floatDistMargin = 0.5f;
	private bool dodging;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Debug.Log(transform.position);
		
		Move();
		
	}

	void Move(){
		Rigidbody rb = GetComponent<Rigidbody>();
		//transform.position -= 0.1f*Vector3.forward;
		//GetComponent<Rigidbody>().velocity = -speed*Vector3.forward;
		rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,-speed);
	}

	IEnumerator Dodge(){
		Rigidbody rb = GetComponent<Rigidbody>();
		//choosing distance and direction random (max is dodgeDistance)
		float distance = Random.Range(-dodgeDistance, dodgeDistance);
		float newX  = transform.position.x + distance;

		Debug.Log("start dodging to go to X = "+newX);
		dodging = true;
		//moving as fast as dodgeSpeed in the right direction til there
		while(Mathf.Abs(newX - transform.position.x) > floatDistMargin){	

			rb.velocity = new Vector3( Mathf.Sign(distance)*dodgeSpeed, rb.velocity.y, rb.velocity.z);
			yield return new WaitForFixedUpdate();
		}
		
		Debug.Log("at "+newX+" finished dodging");
		dodging = false;
		rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
	}


	public void OnTriggerStay(Collider other){
		if(other.CompareTag("Obstacle") && !dodging){
			StartCoroutine(Dodge());
		}
	}
}
