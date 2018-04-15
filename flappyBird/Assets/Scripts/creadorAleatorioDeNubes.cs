using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creadorAleatorioDeNubes : MonoBehaviour
{

	public GameObject nube;
	List<GameObject> nubesGuardadas;
	public float tiempoDeGeneracionDeNubes = 3f;
	public float nubesActivasMaximas = 3f;
	float nubesActivasActualmente;

	Vector2 posicionInicialNube = new Vector2 (0, 0);
	public float limiteDestuccionNube = -7f;

	// Use this for initialization
	void Start ()
	{
		nubesGuardadas = new List<GameObject> ();
		comprobarAntesDePonerNube ();
	}

	// Update is called once per frame
	void Update ()
	{
		//cuando llegue al limite se destruya la nube
		for (int i = 0; i < nubesActivasActualmente; i++) {
			GameObject clon = nubesGuardadas [i];
			if (clon.transform.position.x < limiteDestuccionNube) {				
				Destroy (clon, 0.5f);
				nubesGuardadas.RemoveAt (i);
				nubesActivasActualmente -= 1f;
			}
		}

		//que se vaya restando el tiempo para poder colocar nube
		tiempoDeGeneracionDeNubes -= Time.fixedDeltaTime;
		comprobarAntesDePonerNube ();		
	}

	void comprobarAntesDePonerNube ()
	{
		if (tiempoDeGeneracionDeNubes <= 0 && nubesActivasActualmente < 3f) {

			ponerNube ();
			tiempoDeGeneracionDeNubes = 3f;

		}
	}

	void ponerNube ()
	{
		//de primeras que cree una posicion para la nube
		posicionInicialNube = new Vector2 (8.1f, Random.Range (1.5f, 4.1f));
		//poner una como activa
		nubesActivasActualmente += 1f;

		//se genera una nube y se inician variables de control.
		nube = (GameObject)Instantiate (nube, posicionInicialNube, Quaternion.identity);
		//se guarda la nube en una matriz
		nubesGuardadas.Add (nube);

	}

}
