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

	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
		if(rb.velocity.y<speed/2f && blockingObstacle){
			blockingObstacle.AddForce(obstaclePush*Vector3.up, ForceMode.Impulse);
		}
	}

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


	public void OnTriggerStay(Collider other){
		// if(other.CompareTag("Obstacle") && !dodging){
		// 	StartCoroutine(Dodge(other));
		// }
	}

	public void OnDestroy(){
		gm.GreenWins();
	}

	public void OnCollisionEnter(Collision col){
		if(col.transform.CompareTag("Obstacle")){
			if(col.transform.parent.name == "Hands"){
				col.transform.parent.parent.GetComponent<PlayerController>().Drop();
			}else{
				blockingObstacle = col.rigidbody;
			}
		}
	}


}
