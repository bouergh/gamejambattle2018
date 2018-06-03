using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
	public Text timerText;
	public float startTime;
    public GameObject looseText;
    public GameObject TimerStop;
    // Use this for initialization
    void Start () {
		startTime = 12;
	}
	
	// Update is called once per frame
	void Update () {
		
		float t = startTime - Time.time;
			string minutes = ((int) t/60).ToString();
			string seconds = ((int) t%60).ToString();

		timerText.text = minutes + ":" + seconds;
       
        if (t < 0.0f) {
            looseText.SetActive(true);
            TimerStop.SetActive(false);
        }
	}


}
