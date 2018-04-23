using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour
{
	public static Gato instancia;

	public Rigidbody2D cuerpo2D;
	public Animator animador;
	public float tiempoAnim = 0.5f;
	public AudioSource auidoVolar;

	public float tapForce = 200;
	public float tiltSmooth = 0.1f;
	public Vector3 startPos;

	Quaternion downRotation;
	Quaternion forwardRotation;

	// Use this for initialization
	void Start ()
	{
		if (instancia == null) {
			instancia = this;
		}
		cuerpo2D = GetComponent<Rigidbody2D> ();
		downRotation = Quaternion.Euler (0, 0, -35);
		forwardRotation = Quaternion.Euler (0, 0, 35);

		animador = GetComponent<Animator> ();
		animador.SetTrigger ("Normal");

	}
	
	// Update is called once per frame
	void Update ()
	{
		//volver a poner el gato en animacion normal
		tiempoAnim -= Time.fixedDeltaTime;
		if (tiempoAnim < 0) { 
			animador.SetTrigger ("Normal");
			tiempoAnim = -1f;
		}
	}

	//tap para que suba
	public void gatoVolar ()
	{		
		cuerpo2D.velocity = Vector3.zero;
		transform.rotation = forwardRotation;
		cuerpo2D.AddForce (Vector2.up * tapForce, ForceMode2D.Force);
		animador.SetTrigger ("Impulso");
		auidoVolar.Play ();
	}

	public void gatoCaidaSuave() {
		//parezca que suba y caiga de forma suave
		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
	}



}
