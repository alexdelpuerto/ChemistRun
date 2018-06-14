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
		if (other.tag == "Player") {				//Si el destructor de abajo colisiona con la cabeza, cuerpo o zapatos
			NotificationCenter.DefaultCenter().PostNotification(this, "Muere");
			GameObject personaje = GameObject.Find("Heisenberg");
			personaje.SetActive(false);			//Desabilito el personaje al morir para parar la camara
		} else {
			Destroy (other.gameObject);				//Destruye los objetos con los que colisiona nuestro destructor
		}
	}
}
