using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour {
	
	//Variables needed for the main menu
	public Canvas InfoMenu;
	public Canvas QuitMenu;
	public Button PlayButton;
	public Button ExitButton;
	public Button InfoButton;
	public GameObject EmptyObject;
	public AudioSource mainMenuMusic;
	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;

	GameObject theInstance;
	static bool firstTime = true;

	// Use this for initialization
	void Start () {
		//Initialize the buttons and canvas
		InfoMenu = InfoMenu.GetComponent<Canvas> ();
		QuitMenu = QuitMenu.GetComponent<Canvas> ();
		InfoButton = InfoButton.GetComponent<Button> ();
		PlayButton = PlayButton.GetComponent<Button> ();
		ExitButton = ExitButton.GetComponent<Button> ();
		muteButton = muteButton.GetComponent<Button> ();
		mainMenuMusic = mainMenuMusic.GetComponent<AudioSource> ();

		//Hide the QuitMenu and InfoMenu and enable the main menu buttons
		InfoMenu.enabled = false;
		QuitMenu.enabled = false;
		PlayButton.enabled = true;
		ExitButton.enabled = true;
		InfoButton.enabled = true;

		if (!firstTime) {
			Destroy (GameObject.Find("EmptyObject(Clone)"));
		}
		theInstance = (GameObject)Instantiate(EmptyObject);
		firstTime = false;	
	}
	
	
	public void PressPlay () {

		GameObject emptyObject = GameObject.Find ("EmptyObject(Clone)");
		emptyObject.GetComponent<StoringVarScript> ().currentLevel = 1;
		Application.LoadLevel ("OpeningScene");
	}


	//Pop up the Info Menu when you press How To and disable the main menu buttons
	public void PressHowTo () {
		
		InfoMenu.enabled = true;
		PlayButton.enabled = false;
		ExitButton.enabled = false;
		InfoButton.enabled = false;
		
		
	}
	
	//Function to enable the button to go back to main menu from the info menu
	public void QuitInfoMenu () {
		
		InfoMenu.enabled = false;
		PlayButton.enabled = true;
		ExitButton.enabled = true;
		InfoButton.enabled = true;
	}
	
	// Bring up the Quit Menu when the player presses quit to confirm 
	// that he wants to quit. Also disable the main menu buttons.
	
	public void PressQuit () {
		QuitMenu.enabled = true;
		PlayButton.enabled = false;
		ExitButton.enabled = false;
		InfoButton.enabled = false;
	}
	
	// Hide the quit menu if the player presses NO in the Quit Menu.
	// Alse enable the Main Menu buttons again.
	public void ExitQuitMenu () {
		QuitMenu.enabled = false;
		PlayButton.enabled = true;
		ExitButton.enabled = true;
		InfoButton.enabled = true;
		
	}
	
	//If the player presses yes in the Quit Menu the game is exited
	public void QuitGame () {
		Application.Quit ();
	}
	
	
	// Update is called once per frame
	void Update () {

	}
}
