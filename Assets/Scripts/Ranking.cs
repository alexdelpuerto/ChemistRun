using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Ranking : MonoBehaviour {

	private TextMesh textoBoton;

	void Awake(){
		textoBoton = GetComponent<TextMesh> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Social.localUser.authenticated) {
			textoBoton.color = Color.blue;
		} else {
			textoBoton.color = Color.grey;
		}
	}

	void OnMouseDown(){
		audio.Play ();

		if (Social.localUser.authenticated) {
			((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIsPOJ0JQIEAIQAQ");
		} else {
			Social.localUser.Authenticate((bool success) => {});
		}
	}
}
