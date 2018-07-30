using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance=null;
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	private AudioSource music;
	int levelLoad=1;

	void Awake(){
		print(SceneManager.GetActiveScene().buildIndex);
		if(instance != null && instance != this){
			Destroy(gameObject);
			print("Desroying duplicate music player");
		}
		else{
		instance=this;
		GameObject.DontDestroyOnLoad(gameObject);
		music = GetComponent<AudioSource>();
		music.clip = startClip;
		music.loop = true;
		music.Play();
		}

	}

	void Update(){
		if(SceneManager.GetActiveScene().buildIndex == levelLoad) {
			levelLoad = levelLoad+1;
			OnSceneLoaded();
			if(levelLoad == 3){ levelLoad = 1; }
		}

	}

/*	void OnLevelWasLoaded(int level){
		Debug.Log("MusicPlayer: Loded Level"+ level);
		music.Stop();
		if(level == 0){
		music.clip = startClip;
		}
		if(level == 1){
		music.clip = gameClip;
		}
		if(level == 2){
		music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}*/

	//void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	void OnSceneLoaded()
 {
		if(music!=null)
 {
     print("HERE IN SCENE LOADED");
		music.Stop();
     if(SceneManager.GetActiveScene().buildIndex==0 )
     {
         Debug.Log("start music");
		 print(SceneManager.GetActiveScene().buildIndex);
         music.clip=startClip;
     }
     else if(SceneManager.GetActiveScene().buildIndex==1)
     {
         Debug.Log("game music");
		 print(SceneManager.GetActiveScene().buildIndex);
		 music.clip=gameClip;
     }
     else if(SceneManager.GetActiveScene().buildIndex==2)
     {
         Debug.Log("end music");
		 print(SceneManager.GetActiveScene().buildIndex);
		 music.clip=endClip;
     }
		music.loop = true;
		music.Play();
     }
 else
 {
     print("audioMusic NULL");
 }
 }

	// Use this for initialization
	void Start () {
		
	    
	}
	

		
	
}
