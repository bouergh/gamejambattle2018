using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoutonLa : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
		GameObject lol;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GGWP()
    {
        text.text = "Bravo t'as gagné :) AI";
    }
}
