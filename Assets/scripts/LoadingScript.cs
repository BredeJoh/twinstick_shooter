using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

	//what will open when pressing 'esc' or 'pause', the player can quit from here
	public GameObject pauseMenu;

	//set this to whatever button code pausebutton on controller is
	private string pauseButton = "pause";
	//set this to whatever keycode that will be used for pausing/quitting
	private string pauseKey = "escape";
	//NOTE:
	//For a scene to load, open the build menu and make sure the scenes you want to use are in
	//the index there; they don't appear to be recognized if not.

	//loads level based on input from various objects, such as buttons (OnClick --> return (int)),
	//OnCollide --> return (int), etc.
	public void LoadLevelByNumber(int levelNumber) {
		SceneManager.LoadScene(levelNumber);
	}

	//same as above, but for strings, aka the name of the scene one would want to load. Should work
	//even if casing isn't the same. Can also be a file path (I think)
	public void LoadLevelByName(string levelName) {
		SceneManager.LoadScene(levelName);
	}

	//the public string defines which level will be loaded unpon colliding
	public string levelName;
	//if something collides with the current object (trigger); load specified level 
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "Player") {
			LoadLevelByName(levelName);
		}
	}
	//makes sure the pause menu isn't open by accident when starting the game
	void Start() {
		pauseMenu.SetActive(false);
	}
	void FixedUpdate() {
		Pausing();
	}

	//pauses game and activates/deactivates the pause menu
	void Pausing() {
		if (Input.GetKeyDown(pauseKey) || Input.GetButtonDown(pauseButton)) {
			//stops time and activates the loading menu uppon pausing
			if (!pauseMenu.activeSelf) {
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
			}
			//unpauses on another press, deactivates the pause menu and starts time again
			else if (pauseMenu.activeSelf){
				pauseMenu.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}

	//quit the game upon clicking a button that points to this
	public void ClickToQuit() {
		Application.Quit();
	}
	//quit the pause menu and start time upon clicking
	public void ClickToCOntinue() {
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
	}
}
