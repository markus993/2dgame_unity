using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
    
    public TextMesh reloj;
    private int paso;
    private int tiempo = 60;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        paso = (int)Time.time;
        reloj.text = (tiempo - paso) + "";
    }
}
