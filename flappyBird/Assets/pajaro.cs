using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajaro : MonoBehaviour {
	// Velocidad a la que se desplaza la nave (medido en u/s)
	private float velocidad = 20f;

	// Fuerza de lanzamiento del disparo
	private float fuerza = 0.5f;

	private Rigidbody2D cuerpo2D;

	// Use this for initialization
	void Start () {
		cuerpo2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
            if (Input.GetKey (KeyCode.UpArrow)) 
            {
                transform.Translate(Vector2.up * 15 * Time.deltaTime);
            }
            if (Input.GetKey (KeyCode.DownArrow)) 
            {
                transform.Translate(Vector2.down * 15 * Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0)){
            	cuerpo2D.velocity = Vector2.zero;
            	cuerpo2D.AddForce(new Vector2(0, 3f));
            }
	}
}
