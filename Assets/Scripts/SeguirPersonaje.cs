using UnityEngine;
using System.Collections;

public class SeguirPersonaje : MonoBehaviour {

	public Transform personaje;			//Se asigna a la camara
	public float separacionIni = 5.28f;	//Para que el personaje empiece centrado en la izquierda

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (personaje.position.x + separacionIni, transform.position.y, transform.position.z);	//Cargo en la posicion de la camara el valor de x del personaje
	}
}
