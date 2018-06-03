using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWinsTrigger : MonoBehaviour {
    public GameObject robot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (robot != null)
        {
            //call UI RED Wins
            Debug.Log("RED WINS");
        }
        
    }
}
