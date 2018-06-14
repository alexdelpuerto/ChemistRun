using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Estado : MonoBehaviour {

	public static Estado estado;
	public int puntuacionMax = 0;
	private string rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";

		if (estado == null) {
			estado = this;
			DontDestroyOnLoad (gameObject);

			PlayGamesPlatform.DebugLogEnabled = false;
			PlayGamesPlatform.Activate();
		} else if (estado != null) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar ();

		//GooglePlayGames
		((PlayGamesPlatform)Social.Active).Authenticate((bool success) => {}, true);
		//Intersticial
		string[] testDeviceIDs = new string[]{"0EA90E1E80DC666D3E0018F91D3623D6"};
		EasyGoogleMobileAds.GetInterstitialManager().SetTestDevices(true, testDeviceIDs);
		EasyGoogleMobileAds.GetInterstitialManager().PrepareInterstitial("ca-app-pub-4397504908042634/8131523708");
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(rutaArchivo);

		DatosAGuardar datos = new DatosAGuardar ();
		datos.puntuacionMax = puntuacionMax;

		bf.Serialize (file, datos);

		file.Close ();
	}


	void Cargar(){
		if(File.Exists(rutaArchivo)){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open(rutaArchivo, FileMode.Open);

		DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (file);
		puntuacionMax = datos.puntuacionMax;

		file.Close ();

		} else{
			puntuacionMax = 0;
		}
	}
}
//Este script es para guardar y cargar la puntuacion maxima entre escenas

[Serializable]
class DatosAGuardar{
	public int puntuacionMax;
}

