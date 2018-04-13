using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetidorFondos : MonoBehaviour
{
	
	public BoxCollider2D sueloCollider;
	public float sueloHorizontal;

	void Awake ()
	{
	
		sueloCollider = GetComponent<BoxCollider2D> ();

		sueloHorizontal = sueloCollider.size.x;
	
	}

	void update ()
	{
		transform.position = (Vector2)transform.position + new Vector2 (sueloHorizontal * 2f, 0);
		if (transform.position.x < -6.5f) {
			VolverAPonerSuelo ();
		}

	}


	void VolverAPonerSuelo ()
	{
		Vector2 groundOffSet = new Vector2 (sueloHorizontal * 2f, 0);

		transform.position = (Vector2)transform.position + groundOffSet;
	}
}
