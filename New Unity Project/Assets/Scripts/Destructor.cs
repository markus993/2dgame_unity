﻿using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Debug.Log ("PerdioJuego");
			NotificationCenter.DefaultCenter().PostNotification(this, "PerdioJuego");
			GameObject personaje = GameObject.Find("CharacterRobotBoy");
			personaje.SetActive(false);
		}else{
			Destroy(other.gameObject);
		}
	}
}
