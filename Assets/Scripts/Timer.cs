using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
	public Text timerText;
	public float startTime;
    public GameObject looseText;
    public GameObject TimerStop;

	public AudioManager am;
	private bool countdown = false;
    // Use this for initialization
    void Start () {
		startTime = 120;
	}
	
	// Update is called once per frame
	void Update () {
		//20s countdown Sound Effect function
		float t = startTime - Time.time;
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
