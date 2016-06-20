using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
		Brick.breakableCount = 0;
	}
	
	public void QuitRequest(){
		Debug.Log("Exit");
		Application.Quit();
	}

	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void brickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
	
	public void LoadPreviousLevel(){
		
	}
	
}

