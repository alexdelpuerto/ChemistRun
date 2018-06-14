using UnityEngine;
using System.Collections;

public class Bloques : MonoBehaviour {

	private bool colisionBloqueJugador = false;
	public int puntosGanados = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (!colisionBloqueJugador && collision.gameObject.tag == "Player") {


			GameObject obj = collision.contacts[0].collider.gameObject;
			if(obj.name == "ZapatosDerecho" || obj.name == "ZapatosIzquierdo"){
				colisionBloqueJugador = true;						//Cuando colisione el primer fotograma que cuente como que ha colisionado
				NotificationCenter.DefaultCenter().PostNotification(this, "SumarPunto", puntosGanados);					
			}
		}
	}
}

