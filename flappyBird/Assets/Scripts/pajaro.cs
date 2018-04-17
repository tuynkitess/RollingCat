using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajaro : MonoBehaviour
{
	// Velocidad a la que se desplaza la nave (medido en u/s)
	private float velocidad = 20f;
	// Fuerza de lanzamiento del disparo
	private float fuerza = 0.5f;

	public Rigidbody2D cuerpo2D;
	public float tapForce = 200;
	public float tiltSmooth = 1;
	public Vector3 startPos;

	Quaternion downRotation;
	Quaternion forwardRotation;

	// Use this for initialization
	void Start ()
	{
		cuerpo2D = GetComponent<Rigidbody2D> ();
		downRotation = Quaternion.Euler (0, 0, -35);
		forwardRotation = Quaternion.Euler (0, 0, 35);

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetMouseButtonDown (0)) {
			cuerpo2D.velocity = Vector3.zero;
			//cuerpo2D.transform.Rotate (Vector3.forward * 20f);
			transform.rotation = forwardRotation;
			cuerpo2D.AddForce (Vector2.up * tapForce, ForceMode2D.Force);
		}

		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

	}

	void OnCollisionEnter2D(Collision2D colisionador)
	{
		// Zero out the bird's velocity
		cuerpo2D.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		//isDead = true;
		//...tell the Animator about it...
		//anim.SetTrigger ("Die");
		//...and tell the game control about it.
		//GameControl.instance.BirdDied ();
	}

}
