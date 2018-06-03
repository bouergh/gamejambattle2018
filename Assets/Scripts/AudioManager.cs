using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour 
{
	public GameObject myMenuMusic;
	public GameObject myGameMusic;
	public GameObject myButtonSFX;
	public GameObject myPickupSFX;
	public GameObject myHitSFX;
	public GameObject myThrow;
	public GameObject myCountdownSFX;

	// Use this for initialization
	void Start () 
	{
        //onMenuStart();
        //onGameStart();
        DontDestroyOnLoad(this.gameObject);
    }
    void Awake() {
        Scene currentScene = SceneManager.GetActiveScene();
       
        if (currentScene.buildIndex == 3) {
            onGameStart();
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log(scene.buildIndex);
        if (scene.buildIndex == 0) {
            onMenuStart();
        }
        if (scene.buildIndex == 1)
        {
            onMenuStart();
        }

    }
    void OnEnable() { Debug.Log("OnEnable called"); SceneManager.sceneLoaded += OnSceneLoaded; }
    // Update is called once per frame
    void Update () 
	{
		
	}

	public void onMenuStart()
	{
		Instantiate (myMenuMusic, new Vector3(0,0,0), Quaternion.identity);

	}

	public void onGameStart()
	{
		Instantiate (myGameMusic, new Vector3(0,0,0), Quaternion.identity);

	}

	public void onButtonPress()
	{
		Instantiate (myButtonSFX, new Vector3(0,0,0), Quaternion.identity);

	}

	public void onPickup()
	{
		Instantiate (myPickupSFX, new Vector3(0,0,0), Quaternion.identity);

	}

	public void onHit()
	{
		Instantiate (myHitSFX, new Vector3(0,0,0), Quaternion.identity);

	}

	public void onThrow()
	{
		Instantiate (myThrow, new Vector3(0,0,0), Quaternion.identity);

	}

	public void onCountdown()
	{
		Instantiate (myCountdownSFX, new Vector3(0,0,0), Quaternion.identity);

	}
}
