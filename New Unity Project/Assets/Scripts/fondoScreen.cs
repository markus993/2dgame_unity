using UnityEngine;
using System.Collections;

public class fondoScreen : MonoBehaviour {
    private GameObject fondo;
    private TextMesh text;
    private int puntuacion = 0;
    private Color color;

    // Use this for initialization
    void Start ()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "CambioColorScreen");
        GameObject fondo = GameObject.Find("FondoCerca");
    }
    void CambioColorScreen(Notification notificacion)
    {

        int puntosAIncrementar = (int)notificacion.data;
        puntuacion += puntosAIncrementar;
        color = GetComponent<Renderer>().material.color;
        if(color.a < 0.704 && color.a > 0)
        {
            Debug.Log(color.a);

            color = new Color(color.r, color.g, color.b, (color.a - 0.01f));
            GetComponent<Renderer>().material.color = color;
        }
      
    }
    // Update is called once per frame
    void Update () {
        
    }
}
