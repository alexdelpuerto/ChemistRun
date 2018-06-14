using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public int puntosGanados = 5;
	public AudioClip itemClip;
	public float volumen = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "SumarPunto", puntosGanados);
			AudioSource.PlayClipAtPoint(itemClip, Camera.main.transform.position, volumen);
		}
		Destroy (gameObject);
	}
}
