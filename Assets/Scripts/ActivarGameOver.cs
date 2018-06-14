using UnityEngine;
using System.Collections;

public class ActivarGameOver : MonoBehaviour {

	public GameObject camaraGameOver;
	public AudioClip gameOverClip;
	public GameObject easyGoogleMobileAds;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "Muere");
	}

	void Muere(Notification notificacion){
		audio.Stop ();
		audio.clip = gameOverClip;
		audio.loop = false;
		audio.Play ();
		camaraGameOver.SetActive (true);
		easyGoogleMobileAds.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
