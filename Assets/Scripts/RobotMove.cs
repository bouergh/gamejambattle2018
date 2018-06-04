using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour {
    
	private GameManager gm;
	public float speed = 3f;
	public float dodgeSpeed = 10f;
	public float dodgeDistance = 1f;
	public float floatDistMargin = 0.5f;
	private bool dodging;
	public Rigidbody blockingObstacle;
	public float obstaclePush;
	private float origX;
	public CharacterSelector cs;

	// Use this for initialization
	void Start () {
		cs = GameObject.Find("GameManager").GetComponent<CharacterSelector>();
		origX = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(cs.start) Move(); //don't move before game start
	}

	void Move(){
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,-speed);

		//go back a little to the center of the map
		rb.velocity += new Vector3(0.01f*(origX-transform.position.x),0f,0f);

		//pas sur de ca jle faisais pour autre chose
		if(rb.velocity.y<speed/2f && blockingObstacle){
			blockingObstacle.AddForce(obstaclePush*Vector3.up, ForceMode.Impulse);
		}
	}


	public void OnCollisionEnter(Collision col){
		if(col.transform.CompareTag("Obstacle")){

			SpringJoint sj = col.gameObject.GetComponent<SpringJoint>();
			if(sj){
				sj.connectedBody.GetComponent<PlayerController>().Drop();
			}
		}
	}


	// public void OnTriggerStay(Collider other){
	// 	if(other.CompareTag("Obstacle") && !dodging){
	// 		StartCoroutine(Dodge(other));
	// 	}
	// }

	
	IEnumerator Dodge(Collider col){

		float gap = 20f; //juste un float qui permet de determiner une position LOIN A GAUCHE
		// ou LOIN A DROITE de l'objet
		float distance;
		bool goLeft = false; //set to true if we dodge left, false if not
		//find the direction to dodge thanks to collider closest extremity
		Vector3 leftSide = transform.position + gap*Vector3.left;
		Vector3 leftFarthersPoint = col.ClosestPointOnBounds(leftSide);
		Vector3 rightSide = transform.position + gap*Vector3.right;
		Vector3 rightFarthersPoint = col.ClosestPointOnBounds(rightSide);

		//setting goLeft
		if((rightFarthersPoint-transform.position).magnitude > (leftFarthersPoint-transform.position).magnitude){
			goLeft = true;
		}
		if(goLeft){
			distance = (leftFarthersPoint-transform.position).x - dodgeDistance;
		}else{
			distance = (rightFarthersPoint-transform.position).x + dodgeDistance;
		}
		Debug.Log(distance);
		
		Rigidbody rb = GetComponent<Rigidbody>();
		//choosing distance and direction random (max is dodgeDistance)
		//distance = Random.Range(-dodgeDistance, dodgeDistance); OLD
		float newX  = transform.position.x + distance;

		//new : choosing distance based on best way to dodge object
		
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



}
