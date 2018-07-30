using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public float health=150f;
	public int scoreValue = 150;
	public ScoreKeeper scoreKeeper;
	public AudioClip dieSound;

	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnCollisionEnter2D (Collision2D collision){
	Projectile missile = collision.gameObject.GetComponent<Projectile>();
	if(missile){
		Destroy(collision.gameObject);
		health -= missile.GetDamage();
		if(health<=0){
			AudioSource.PlayClipAtPoint(dieSound, transform.position);
			Destroy(gameObject);
			scoreKeeper.Score(scoreValue);
			}
		}
	}
}
