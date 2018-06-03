using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour 
{
	private float i = 0; 
	private float myRand; 

	private AudioClip myClip; 
	private AudioSource mySource; 
	public AudioClip[] myClips; 

	// Use this for initialization
	void Start () 
	{
		//get source
		mySource = gameObject.GetComponentInChildren<AudioSource> ();

		//choose clip
		myClip = myClips[Random.Range(0,myClips.Length)];

		//random pitch
		float myRand = Random.Range (1f, 1.5f); 
		mySource.pitch = myRand; 

		//load and play clip
		mySource.clip = myClip;
		mySource.Play ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		i += Time.deltaTime;

		if (i > mySource.clip.length) 
		{
			mySource.volume -= Time.deltaTime;

			if (mySource.volume == 0) 
			{
				i = 0;

				Destroy(gameObject);
                print("I deid2");
            }


		}
		
        		
	}

    public void KillMe() {
        Destroy(gameObject);
        print("I deid");
    }

}
