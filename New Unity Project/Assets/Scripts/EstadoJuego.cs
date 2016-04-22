using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;
	public string nombreEscenaParaCargar = "portada";
	public TextMesh mensaje;

	public static EstadoJuego estadoJuego;
	
	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if(estadoJuego==null){
			estadoJuego = this;
			DontDestroyOnLoad(gameObject);
		}else if(estadoJuego!=this){
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar();
		NotificationCenter.DefaultCenter().AddObserver(this, "GanoJuego");
		NotificationCenter.DefaultCenter().AddObserver(this, "PerdioJuego");
	}

	void PerdioJuego(Notification notificacion){
		Debug.Log ("PerdioJuego Notificacion");
		string mensaje = (string)notificacion.data;

		GameObject personaje = GameObject.Find("CharacterRobotBoy");
		personaje.SetActive(false);
		GameObject aviso = GameObject.Find("mensaje");
		//mensaje.text = "Has Perdido\nTiempo:"+mensaje;
		aviso.transform.TransformVector(new Vector3(0,0,0));
	}

	void GanoJuego(Notification notificacion){
		int tiempo = (int)notificacion.data;

		GameObject personaje = GameObject.Find("CharacterRobotBoy");
		personaje.SetActive(false);
		mensaje.text = "Has Ganado\nTiempo:"+tiempo;
		puntuacionMaxima = tiempo;
		Guardar();
		mensaje.transform.TransformVector(new Vector3(0,0,0));
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(rutaArchivo);
		
		DatosAGuardar datos = new DatosAGuardar();
		datos.puntuacionMaxima = puntuacionMaxima;
		
		bf.Serialize(file, datos);
		
		file.Close();
	}
	
	void Cargar(){
		if(File.Exists(rutaArchivo)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(rutaArchivo, FileMode.Open);
			
			DatosAGuardar datos = (DatosAGuardar) bf.Deserialize(file);
			
			puntuacionMaxima = datos.puntuacionMaxima;
			
			file.Close();
		}else{
			puntuacionMaxima = 0;
		}
	}
}

[Serializable]
class DatosAGuardar{
	public int puntuacionMaxima;
}