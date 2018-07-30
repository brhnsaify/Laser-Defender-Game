using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed=15.0f;
	float xmin;
	float xmax;
	public GameObject projectile;
	public float projectileSpeed;
	float firingRate=0.2f;
	public static float health = 1000f;

	//public static float life;
	public AudioClip fireSound;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
		xmin = leftMost.x;
		xmax = rightMost.x;
		health = 1000f;
		}

	void Fire(){
		Vector3 offset = new Vector3(0, 1, 0);
		GameObject beam = Instantiate(projectile, transform.position+offset, Quaternion.identity);
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);	
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0))){
			InvokeRepeating("Fire", 0.000001f, firingRate);
			}

		if((Input.GetKeyUp(KeyCode.Space)) || (Input.GetMouseButtonUp(0))){
			CancelInvoke("Fire");
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			//transform.position += new Vector3(-speed*Time.deltaTime, 0f, 0f);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)){
			//transform.position += new Vector3(speed*Time.deltaTime, 0f, 0f);
			transform.position += Vector3.right * speed * Time.deltaTime;

		}

		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position=new Vector3(newX, transform.position.y, transform.position.z);
		
	}

	public void Key(){
		if(Input.anyKey){print("hui");}
		else if(Input.anyKeyDown) {print("hui down");}
		else if(Input.GetMouseButton(0)){print("mouse hua ");}
		else if(Input.GetMouseButtonDown(0)){print("mouse down hu");}
		else if(Input.GetMouseButtonUp(0)){print("mouse uop hua");}
		else print("kuch nhi hua");
	}

	public void LeftButtonPress(){
		bool check=true;
		int a=0;
		transform.position += Vector3.left * speed * Time.deltaTime;
		//Key();
		if(Input.GetMouseButtonUp(0)){
			print("hello");
			//check = false;
		}
		while(check){
			print(a);
			a++;
			check=false;
		}
		print("a yha tak chal"+a);
		//InvokeRepeating("LeftButtonPress", 0.000001f, firingRate);
		//CancelInvoke("Fire");
	    //transform.position += new Vector3(-speed*Time.deltaTime, 0f, 0f);
		//print("left wala");
	}

	public void RightButtonPress(){
		transform.position += Vector3.right * speed * Time.deltaTime;
		//print("right wala");
	}



	void OnCollisionEnter2D (Collision2D collision){
	Projectile missile = collision.gameObject.GetComponent<Projectile>();
	if(missile){
		Destroy(collision.gameObject);
		health -= missile.GetDamage();
		if(health<=0){
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Loose");
		Destroy(gameObject);
		}

		}
	}

}
