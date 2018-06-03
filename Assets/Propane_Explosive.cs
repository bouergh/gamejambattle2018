//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Propane_Explosive : MonoBehaviour {
//    public bool isGrabbed = false;

//    public float timer = 1f;
//    Renderer rend;
//    public float radius = 5.0f;
//    public float power = 10.0f;

//    // Use this for initialization
//    void Start () {
//        rend = GetComponent<Renderer>();
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//        if (isGrabbed)
//        {
//            WillGoBoom(); 
//        }

//        if (timer <= 0)
//        {

//        }
//	}

//    private void OnTriggerEnter(Collider other)
//    {
//        isGrabbed = true;
//    }

//    void RunTimer()
//    {
//        timer -= Time.deltaTime;
//    }
//    void WillGoBoom()
//    {
//        RunTimer();
//        if (timer > 1.5f)
//        {
//            rend.material.color = Color.green; 
//        }
//        else if (timer <= 1.5f && timer > 0.5f)
//        {
//            rend.material.color = Color.yellow; 
//        }
//        else if (timer <= 0.5f && timer > 0)
//        {
//            rend.material.color = Color.white;
//        }
//        else if (timer <= 0)
//        {
//            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
//            foreach (Collider hit in colliders)
//            {
//                Rigidbody rb = hit.GetComponent<Rigidbody>();

//                if (rb != null)
//                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
//            }
//            Destroy(this.gameObject);
//        }

//    }
