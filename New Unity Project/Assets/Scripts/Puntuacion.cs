using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "ResetPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		ActualizarMarcador();
	}
	
	/*void PersonajeHaMuerto(Notification notificacion){
		if(puntuacion > EstadoJuego.estadoJuego.puntuacionMaxima){
			EstadoJuego.estadoJuego.puntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar();
		}
	}*/

	void ResetPuntos(Notification notificacion){
		puntuacion = 0;
	}
	
	void IncrementarPuntos(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion+=puntosAIncrementar;

        NotificationCenter.DefaultCenter().PostNotification(this, "CambioColorScreen", puntuacion);
        ActualizarMarcador();
		if (puntuacion >= 100) {
			Debug.Log ("GANO");
			NotificationCenter.DefaultCenter().PostNotification(this, "GanoMensaje");
			NotificationCenter.DefaultCenter().PostNotification(this, "GanoJuego", puntuacion);
		}
	}

	void ActualizarMarcador(){
		marcador.text = puntuacion.ToString();
	}

	void PersonajeHaMuerto(Notification notificacion){
		marcador.text = puntuacion.ToString();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
