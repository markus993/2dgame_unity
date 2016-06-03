using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
    
    public TextMesh reloj;
	public TextMesh mensaje;
    private int paso;
	public int tiempo = 60;
	private bool stop = false;
	private int pausa = 240;

    // Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "ResetTiempo",tiempo);
		NotificationCenter.DefaultCenter().AddObserver(this, "GanoJuego",tiempo);
		NotificationCenter.DefaultCenter().AddObserver(this, "GanoMensaje",tiempo);
		NotificationCenter.DefaultCenter().AddObserver(this, "PerdioMensaje",tiempo);
		mensaje.text = "";
    }

	void ResetTiempo(Notification notificacion){
		tiempo = 60;
	}

	void GanoJuego(Notification notificacion){
		tiempo = 60;
	}

	void GanoMensaje( ){
		mensaje.text = "Has Ganado";
		stop = true;
	}
	void PerdioMensaje( ){
		mensaje.text = "Has Perdido";
		stop = true;
	}

	// Update is called once per frame
	void Update ()
    {
        paso = (int)Time.timeSinceLevelLoad;
        reloj.text = (tiempo - paso) + "";
		if ((tiempo - paso) <= 0) {
			PerdioMensaje();
			NotificationCenter.DefaultCenter().PostNotification(this, "PerdioJuego", "Tiempo");
		}
		if(stop == true){
			Debug.Log ("stop: "+pausa);
			pausa--;
			if(pausa <= 0){
				stop = false;
				NotificationCenter.DefaultCenter().PostNotification(this, "ReiniciaJuego");
			}
		}
    }
}
