using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDiaplay : MonoBehaviour {

	void Update () {
		Text myText = GetComponent<Text>();
		//myText.text = PlayerLife.life.ToString();
		myText.text = PlayerController.health.ToString();
	}
}
