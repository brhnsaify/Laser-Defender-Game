using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width;
	public float height;
	float xmin;
	float xmax;
	public float speed=3f;
	public bool movingRight=true;
	public float spawnDelay = 0.5f;
	static int a=0;
	static int b=0;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
		xmin = leftMost.x;
		xmax = rightMost.x;
		SpwanEnemies();
	}

	void SpwanEnemies(){
		foreach ( Transform child in transform ){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntillFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
			b= b+1;
			//print("BS spq"+b);
		    }
		if(NextFreePosition()){
			Invoke("SpawnUntillFull", spawnDelay);
		}
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}

	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
		}else {
			transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
		}

		float rightEdgeOfCube = transform.position.x + (width*0.5f);
		float leftEdgeOfCube = transform.position.x - (width*0.5f);

		if(leftEdgeOfCube < xmin){
			movingRight = true;
		}else if( rightEdgeOfCube > xmax){
			movingRight = false;
		}
		if (AllMembersAreDead()){
			Debug.Log("Empty Enemy");
			SpwanEnemies();
			//print("hai");
		}
	}

	Transform NextFreePosition(){
		
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){
				a = a+1;
				//print("BS"+ a + childPositionGameObject.childCount);
				return childPositionGameObject;
			}
		}
		print("BS null");
			return null;
	}

	bool AllMembersAreDead(){
		print(transform.childCount);
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount>0){
				//print("false");
				return false;
			}
		}
			//print("true");
			return true;
	}
}
