using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {


	public PlayerController[] characters;	//wtf ca marche pourtant
	public Image[] buttons;
	private bool[] selected;
	private bool[] controllerInUse;
	public bool start = false; //start observe par Timer et RobotMove pour commencer le jeu

	public GameObject canvasRules;
	public Rigidbody doorWhichWillFall;

	public Text startText;
	private string origStartText;
	public Text selectText;
	private bool blinking;


	// Use this for initialization
	void Start () {
		//init controller state to none used
		controllerInUse = new bool[4];
		for(int i=0; i<controllerInUse.Length;i++) controllerInUse[i] = false;
		//init selected player to none selected
		selected = new bool[buttons.Length];
		for(int i =0; i<buttons.Length; i++){
			selected[i] = false;
			Debug.Log("Press "+buttons[i].name+" to play "+characters[i].gameObject.name);	//debug/editor instructions
		}
		start = false;
		blinking = false;

		//don't show the "press start" at first
		origStartText = startText.text;
		startText.text = "";
		startText.transform.parent.GetComponent<Text>().text = "";
	}
	
	
	// Update is called once per frame
	void Update () {
		//for debug only please comment out
		for (int i = 0;i < 20; i++) {
			if(Input.GetKeyDown("joystick 1 button "+i)){
				print("joystick 1 button "+i);
			}
		}
		
		//loop to select and then start
		if(!start){
			for(int i =0; i<buttons.Length; i++){
				if(!selected[i]) SelectPlayer(i);
			}
			StartGame();
			
		}
	}

	//joystick ? button ??
	//pour ?? : A=0, B=1, X=2, Y=3
	void SelectPlayer(int j){
		for (int i = 0;i < controllerInUse.Length; i++) {	//pour l'instant gestion des manettes 1 à 4 uniquement
				//if(!controllerInUse[i] && Input.GetKeyDown("joystick "+(i+1)+" button "+j)){ //1 player can only control 1 character here
				if(Input.GetKeyDown("joystick "+(i+1)+" button "+j)){	//pour test osef de la condition du dessus
					Debug.Log("Player "+characters[j].gameObject.name+" associated with controller "+(i+1));
					selected[j] = true;
					AssociateControllerToCharacter(i+1, j);
				}
			}
	}
	void StartGame(){
		//verify at least 1 player connected
		bool okgo = false;
		for (int i = 0;i < selected.Length; i++) {
			okgo = okgo || selected[i];
		}
		//check for start button press
		if(okgo){

			for (int i = 0;i < selected.Length; i++) {
				okgo = okgo && selected[i]; //this time if ALL are valid we hide stuff and highlight START
			}
			if(okgo){
				selectText.text = "";
				selectText.transform.parent.GetComponent<Text>().text = "";
				if(!blinking) StartCoroutine(RedBlink(startText));
			}

			//now show the start text :
			startText.text = origStartText;
			startText.transform.parent.GetComponent<Text>().text = origStartText;

			for (int i = 0;i < buttons.Length; i++) {
				if(Input.GetKeyDown("joystick "+(i+1)+" button 7") || Input.GetKeyDown("return")){
					//Debug.Log("game started");
					start = true;
					Destroy(canvasRules); //destroy the how to play
					doorWhichWillFall.isKinematic = false; //so the door can fall from the robot pushing it
					//destroy inactive players
					for(int j =0; j<characters.Length; j++){
						if(!selected[j]){
							Destroy(characters[j].gameObject);
						}else{
							characters[j].gameObject.GetComponent<Rigidbody>().isKinematic = false; //player can't move before start or bug will happen
						}
					}
				}
			}
		}
		if(!okgo){
			for (int i = 0;i < buttons.Length; i++) {
				if(Input.GetKeyDown("joystick "+(i+1)+" button 7") || Input.GetKeyDown("return")){
					if(!blinking) StartCoroutine(RedBlink(selectText));
				}
			}
		}
		
	}

	void AssociateControllerToCharacter(int controllerNumber, int playerNumber){
			controllerInUse[controllerNumber] = true;
			selected[playerNumber] = true;
			buttons[playerNumber].enabled = false;
			characters[playerNumber].AssociateController(controllerNumber);
	}

	IEnumerator RedBlink(Text text){
		print("text blinking");
		blinking = true;
		float timer = 0.8f;
		float delay = 0.1f;
		float counter = 0f;
		while(counter < timer){
			text.color = Color.red;
			yield return new WaitForSeconds(delay);
			text.color = Color.white;
			yield return new WaitForSeconds(delay);
			counter += 2*delay;
		}
		blinking = false;
	}
}
