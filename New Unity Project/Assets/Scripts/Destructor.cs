using UnityEngine;
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
			NotificationCenter.DefaultCenter().PostNotification(this, "PerdioJuego");
			NotificationCenter.DefaultCenter().PostNotification(this, "PerdioMensaje");
			NotificationCenter.DefaultCenter().PostNotification(this, "ResetTiempo");
			NotificationCenter.DefaultCenter().PostNotification(this, "ResetPuntos");
			GameObject personaje = GameObject.Find("CharacterRobotBoy");
			//personaje.SetActive(false);
		}else{
			Destroy(other.gameObject);
		}
	}
}
