using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;  //Los bloques
	public float tMin = 1.25f;
	public float tMax = 2.75f;

	private bool fin = false;
	// Use this for initialization
	void Start () {					
		NotificationCenter.DefaultCenter ().AddObserver (this, "Comienzo");		//Llama a los metodos cuando se empieza a correr
		NotificationCenter.DefaultCenter ().AddObserver (this, "Muere");
	}

	void Muere(){
		fin = true;
	}

	void Comienzo(Notification notificacion){
		Generar ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void Generar() {
		if (!fin) {
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity); //Genera los bloque de forma aleatoria
			Invoke ("Generar", Random.Range (tMin, tMax));											  //Hago una llamada al metodo cada cierto tiempo			
		}
	}
}
