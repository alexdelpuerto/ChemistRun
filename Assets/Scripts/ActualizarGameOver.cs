using UnityEngine;
using System.Collections;

public class ActualizarGameOver : MonoBehaviour {

	public TextMesh total;		//Referencia al gameobject para modificar puntostotal
	public TextMesh record;		//Referencia al gameobject para modificar puntosrecord
	public Puntuacion puntuacion;	//Referencia a la puntuacion actual de la camara principal

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		total.text = puntuacion.puntuacion.ToString ();			//Actualizar el valor con el valor de la camara
		if (Estado.estado != null) {
			record.text = Estado.estado.puntuacionMax.ToString ();	//Actualizar el valor con el valor del estado
		}
	}
}
