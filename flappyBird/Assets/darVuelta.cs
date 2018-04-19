using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darVuelta : MonoBehaviour
{

	SpriteRenderer imagen;
	public int aRotar = -1;
	// Use this for initialization
	void Start ()
	{

		imagen = GetComponent<SpriteRenderer> ();
		aRotar = Random.Range (1, 3);
		//Si sale 0 cambia la forma de la nube para que no todas parezcan las mismas
		if (aRotar == 1) {
			imagen.flipX = true;
		} else {
			imagen.flipX = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
