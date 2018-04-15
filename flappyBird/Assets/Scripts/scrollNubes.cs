using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollNubes : MonoBehaviour {

	public Rigidbody2D cuerpo2D;
	//public float velocidadDesplazamiento = -1.5f;

	public float velocidadMinima = -0.5f;
	public float velocidadMaxima = -2.0f;
	// Use this for initialization
	void Start () {
		cuerpo2D = GetComponent<Rigidbody2D> ();
		cuerpo2D.velocity = new Vector2 (Random.Range (velocidadMinima, velocidadMaxima), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
