using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {

	public string escena = "GameScene";

	public static int partida = 1;
	private const int partidasParaMostrarIntersticial = 4;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(Application.loadedLevelName == "MainScene"){
			Application.Quit ();
			}
			else if(Application.loadedLevelName == "GameScene"){
				Application.LoadLevel ("MainScene");
			}
		}
	}

	void OnMouseDown(){		
		Camera.main.audio.Stop ();				//Detiene el audio principal
		audio.Play ();							//Reproduce el audio del boton
		Invoke ("CargarNivel", audio.clip.length);
	}

	void CargarNivel(){
		if (Application.loadedLevelName == "GameScene") {
			if(partida == partidasParaMostrarIntersticial){
			EasyGoogleMobileAds.GetInterstitialManager ().ShowInterstitial ();
				partida = 1;
			} else{
				partida++;
			}
		}
		Application.LoadLevel (escena);	//Cambia de escena al pulsar el boton
	}
}
