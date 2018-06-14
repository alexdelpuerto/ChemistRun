using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "SumarPunto"); //Se recibe lo del metodo
		NotificationCenter.DefaultCenter ().AddObserver (this, "Muere");
		ActualizarPuntos ();
	}

	void Muere(Notification notificacion){
		if (puntuacion > Estado.estado.puntuacionMax) { //Se accede a la puntuacion porque es estatica
			Estado.estado.puntuacionMax = puntuacion;	//Actualizar
			Estado.estado.Guardar ();					//Guardar
			}
		//Enviar puntuacion a google
		Social.ReportScore (puntuacion, "CgkIsPOJ0JQIEAIQAQ", (bool success) => {});

		//Activar Medallas
		if (puntuacion >= 25) {
			Social.ReportProgress("CgkIsPOJ0JQIEAIQAg", 100.0, (bool success) => {});
		}
		if (puntuacion >= 50) {
			Social.ReportProgress ("CgkIsPOJ0JQIEAIQAw", 100.0, (bool success) => {});
		}
		if (puntuacion >= 100) {
			Social.ReportProgress("CgkIsPOJ0JQIEAIQBA", 100.0, (bool success) => {});
		}
		if (puntuacion >= 150) {
			Social.ReportProgress("CgkIsPOJ0JQIEAIQBQ", 100.0, (bool success) => {});
		}
		if (puntuacion >= 200) {
			Social.ReportProgress("CgkIsPOJ0JQIEAIQBg", 100.0, (bool success) => {});
		}
	}

	void SumarPunto(Notification notificacion){
		int puntosAIncrementar = (int)notificacion.data;		//Cogemos los puntos de la notificacion
		puntuacion = puntuacion + puntosAIncrementar;			//Aumento puntiacion
		ActualizarPuntos ();									//Actualizar el marcador
	}

	void ActualizarPuntos(){
		marcador.text = puntuacion.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
