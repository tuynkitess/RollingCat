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
		/*
            if (Input.GetKey (KeyCode.UpArrow)) 
            {
                transform.Translate(Vector2.up * 15 * Time.deltaTime);
            }
            if (Input.GetKey (KeyCode.DownArrow)) 
            {
                transform.Translate(Vector2.down * 15 * Time.deltaTime);
            }*/

		if (Input.GetMouseButtonDown (0)) {
			cuerpo2D.velocity = Vector3.zero;
			//cuerpo2D.transform.Rotate (Vector3.forward * 20f);
			transform.rotation = forwardRotation;
			cuerpo2D.AddForce (Vector2.up * tapForce, ForceMode2D.Force);
		}

		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

	}

	void OnTriggerEnted2D (Collider2D colisionador)
	{
		
	}
}
