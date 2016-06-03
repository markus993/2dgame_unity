using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
    
    public TextMesh reloj;
    private int paso;
	public int tiempo = 60;

    // Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "ResetTiempo",tiempo);
		NotificationCenter.DefaultCenter().AddObserver(this, "GanoJuego",tiempo);
    }

	void ResetTiempo(Notification notificacion){
		tiempo = 60;
	}

	// Update is called once per frame
	void Update ()
    {
        paso = (int)Time.timeSinceLevelLoad;
        reloj.text = (tiempo - paso) + "";
		if ((tiempo - paso) <= 0) {
			NotificationCenter.DefaultCenter().PostNotification(this, "PerdioJuego", "Tiempo");
		}
    }
}
