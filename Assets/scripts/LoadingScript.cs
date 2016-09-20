using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

	//NOTE:
	//For a scene to load, open the build menu and make sure the scenes you want to use are in
	//the index there; they don't appear to be recognized if not.

	//loads level based on input from various objects, such as buttons (OnClick --> return (int)),
	//OnCollide --> return (int), etc.
	public void LoadLevelByNumber(int levelNumber) {
		SceneManager.LoadScene(levelNumber);
	}

	//same as above, but for strings, aka the name of the scene one would want to load. Should work
	//as long as the spelling is 100% identical. Can use file paths too it seems (such as "Scenes/Level1")
	//in place of just the name ("Level1"), in case you have a scene in a different folder (for sorting,
	//I guess, haven't really texted this thoroughly)
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
}
