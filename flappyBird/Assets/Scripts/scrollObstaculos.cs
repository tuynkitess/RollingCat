using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollObstaculos : MonoBehaviour {

	public Rigidbody2D palo;
	//public Rigidbody2D palo2;
	//public Rigidbody2D control;

	public float velocidadDesplazamiento = -1.5f;



	// Use this for initialization
	void Start () {
		palo = GetComponent<Rigidbody2D> ();
		palo.velocity = new Vector2 (velocidadDesplazamiento, 0);
		//palo2.velocity = new Vector2 (velocidadDesplazamiento, 0);
		//control.velocity = new Vector2 (velocidadDesplazamiento, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
