using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoutonLa : MonoBehaviour {

    public Text text;
    public Button buttonDead;

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
        buttonDead.GetComponent<Image>().enabled = true;
        buttonDead.GetComponentInChildren<Text>().enabled = true;
    }

    public void Dead()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
