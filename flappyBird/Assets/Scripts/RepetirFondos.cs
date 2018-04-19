using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondos : MonoBehaviour
{

	public BoxCollider2D sueloCollider;
	 public float sueloTamaño = 8f;

	private void Awake ()
	{
	
		sueloCollider = GetComponent<BoxCollider2D> ();
		sueloTamaño = sueloCollider.size.x;

	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.x < -sueloTamaño-2f) {
			VolverAPonerSuelo ();
		}

	}

	private void VolverAPonerSuelo ()
	{
	
		Vector2 groundOffSet = new Vector2 ((sueloTamaño * 2f)+4f, 0);
		transform.position = (Vector2)transform.position + groundOffSet;
	}
}
