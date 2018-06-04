using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
	public Text timerText;
	public float startTime = 120f; //configure in editor
    public GameObject looseText;
    public GameObject TimerStop;

	public AudioManager am;
	private bool countdown = false;
	public float t = 120f; //variable pour le timer. publique pour les tests plus rapides
    // Use this for initialization
    void Start () {
		t = startTime;
		countdown = false;
	}
	
	// Update is called once per frame
	void Update () {
		//20s countdown Sound Effect function
		t -= Time.deltaTime; //faut faire comme ca sinon on peut pas recommencer de partie

		string minutes = ((int) t/60).ToString();
		string seconds = ((int) t%60).ToString();

		timerText.text = minutes + ":" + seconds;
       
        if (t < 0.0f) {
            looseText.SetActive(true);
            TimerStop.SetActive(false);
            SceneManager.LoadScene("BlueWins");
        }

		if(t < 18f && !countdown){
			countdown = true;
			am.onCountdown();
		}
	}


}
