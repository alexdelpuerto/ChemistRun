using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaSalto = 15f;			//Fuerza de salto, prevalece la de Unity a la que se pone aqui
	private bool enSuelo = true; 			//Comprueba si toca suelo
	public Transform comprobarSuelo;		//Para obtener datos
	private float comprobarRadio = 0.07f;	//Radio de la colision obtenido probando
	public LayerMask mascaraSuelo;			//Para definir en que capa se produce la colision
	private bool dobleSalto = false;		//Para que pueda saltar dos veces

	private Animator animator;				//Para el metodo Awake

	private bool corriendo = false;
	public float velocidad = 6f;

	void Awake(){								//Modifica la animacion del juego (Saltar, correr, detenido)
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}

	//Funcion que se llama cada cierto tiempo fijo
	void FixedUpdate(){
		if (corriendo) {
			rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
		}
		animator.SetFloat ("VelocidadX", rigidbody2D.velocity.x);		//Hace que en la animacion, la variable velocidadx vaya cambiando


		enSuelo = Physics2D.OverlapCircle (comprobarSuelo.position, comprobarRadio, mascaraSuelo);  
		animator.SetBool ("enTierra", enSuelo);			//De esta forma se cambia el estado en la animacion cada vez que se toca suelo
		if (enSuelo) {
			dobleSalto = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {				//Comprueba si se toca con el raton o el dedo, y aumenta la posicion del eje Y
			if(corriendo){
				if(enSuelo || !dobleSalto){
					audio.Play();
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, fuerzaSalto);	//Sirve para aumentar la posicion en el eje Y cuando salta
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
					if(!dobleSalto && !enSuelo){
						dobleSalto = true;				//Sirve para permitir el doble salto
					}
					
				}
			} else{
				corriendo = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "Comienzo");
				}

		}
	}
}