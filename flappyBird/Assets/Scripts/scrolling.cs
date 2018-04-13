using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
	public Rigidbody2D cuerpo2D;
	 float velocidadDesplazamiento = -1.5f;

	// Use this for initialization
	void Start ()
	{

		cuerpo2D = GetComponent<Rigidbody2D> ();
		cuerpo2D.velocity = new Vector2 (velocidadDesplazamiento, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
