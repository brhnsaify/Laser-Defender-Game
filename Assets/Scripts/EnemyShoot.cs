using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject projectile1;
	public float projectileSpeed=10f;
	//float firingRate=0.2f;
	//public float speed=5f;
	public float shotsPerSecond = 0.5f;
	public AudioClip enemyFireSound;



	void Fire(){
		AudioSource.PlayClipAtPoint(enemyFireSound, transform.position);
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject enemyBeam = Instantiate(projectile1, startPosition, Quaternion.identity) as GameObject;
		enemyBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);	
	}

	
	// Update is called once per frame
	void Update () {
		float probablity = Time.deltaTime * shotsPerSecond;
		if(Random.value < probablity){
		Fire();
		}
		//transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
		//InvokeRepeating("Fire", 0.000001f, firingRate);	
	}
}
