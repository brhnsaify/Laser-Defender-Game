using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour {

	//public LevelManager levelManager;
	public SceneManager loadScene;

	void OnTriggerEnter2D (Collider2D trigger){
	print("Trigger");
	//levelManager.LoadLevel("Win");
	SceneManager.LoadScene("Loose");
	}

	void OnCollisionEnter2D (Collision2D collision){
	print("Collision");
	}
}
