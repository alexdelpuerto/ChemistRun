using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidadFondo = 0f;
	private bool corriendo = false;
	private float tiempoIni = 0f;

	public bool IniciarEnMovimiento = false; //Para la pantalla de inicio

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "Comienzo");
		NotificationCenter.DefaultCenter ().AddObserver (this, "Muere");
		if (IniciarEnMovimiento) {
			Comienzo();
		}
	}

	void Muere(){
		corriendo = false;
	}

	void Comienzo(){
		corriendo = true;
		tiempoIni = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (corriendo) {
			renderer.material.mainTextureOffset = new Vector2 (((Time.time - tiempoIni) * velocidadFondo) % 1, 0); //Para cambiar el centro de la textura y poder mover la imagen
		}
	}
}