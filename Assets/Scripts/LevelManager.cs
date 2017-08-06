using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {	
	
	public InputField password;
	
	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel(name);
		Bricks.breakCount=0;
		LoseCollider.lifeNumber = 3;
	}
	
	public void QuitRequest () {
		Debug.Log ("I wanna quit!");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		if(Bricks.breakCount <= 0) {
			Application.LoadLevel(Application.loadedLevel + 1);
			Ball.bounce = 0;
		}
	}
	
	public void brickDestroyed () {
		LoadNextLevel();
	}
	
	public void passwordLevel (InputField input) {
		string mypass = input.text;
		if (mypass == "pass") {
			LoadLevel("Level_02");
		} else if (mypass == "word") {
			LoadLevel("Level_03");
		} else if (mypass == "skip") {
			LoadLevel("Level_04");
		} else if (mypass == "done") {
			LoadLevel ("Level_05") ;
		} else if (mypass == "ends") {
			LoadLevel("Level_06");
		} else {
			Debug.LogError ("Wrong Password");
		}
	}
}