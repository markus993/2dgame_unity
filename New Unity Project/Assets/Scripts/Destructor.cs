using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {
	public TextMesh mensaje;

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
			NotificationCenter.DefaultCenter().PostNotification(this, "ResetTiempo");
			NotificationCenter.DefaultCenter().PostNotification(this, "ResetPuntos");
			GameObject personaje = GameObject.Find("CharacterRobotBoy");
			//personaje.SetActive(false);
			mensaje.text = "Has Perdido";
			System.Threading.Thread.Sleep(2000); 
			mensaje.text = "";
			Application.LoadLevel("Portada");
		}else{
			Destroy(other.gameObject);
		}
	}
}
