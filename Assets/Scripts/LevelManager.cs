using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level load requested for:"+name);
		//Application.LoadLevel(name);
		//Brick.breakableCount=0;
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log("Yes Quit");
		Application.Quit();

	}  

	public void LoadNextLevel(){
		//Brick.breakableCount=0;
		//SceneManager.LoadScene(Application.loadedLevel + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		//Application.LoadLevel(Application.loadedLevel +1);
	}
	/*
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			print("hello");
			LoadNextLevel();
			print("hii");
		}
	}*/
}
