using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creadoraDeColumnas : MonoBehaviour
{

	public static creadoraDeColumnas instancia;

	public GameObject columna;
	List<GameObject> columnasGuardadas;

	float tiempoDeGeneracionDeColumnas;
	public float tiempoFijoDeGeneracionDeColumnas = 2f;

	public float columnasActivasMaximas = 10f;
	float columnasActivasActualmente;

	Vector3 posicionInicialColumna = new Vector3 (0, 0, -1f);
	public float limiteDestruccionColumna = -7f;
	public float alturaMaxima = 3.5f;
	public float alturaMinima = 0;

	public Rigidbody2D columna2d;

	// Use this for initialization
	void Start ()
	{
		if (instancia == null) {
			instancia = this;
		}
		//comodidad a la hora de probar velocidades
		tiempoDeGeneracionDeColumnas = tiempoFijoDeGeneracionDeColumnas;

		columnasGuardadas = new List<GameObject> ();
		//comprobarAntesDePonerColumna ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void creadoraColumnas ()
	{
		//cuando llegue al limite se destruya la nube
		for (int i = 0; i < columnasActivasActualmente; i++) {
			GameObject clon = columnasGuardadas [i];
			if (clon.transform.position.x < limiteDestruccionColumna) {				
				Destroy (clon, 0.5f);
				columnasGuardadas.RemoveAt (i);
				columnasActivasActualmente -= 1f;
			}
		}

		//que se vaya restando el tiempo para poder colocar nube
		tiempoDeGeneracionDeColumnas -= Time.fixedDeltaTime;
		comprobarAntesDePonerColumna ();
	}

	void comprobarAntesDePonerColumna ()
	{
		if (tiempoDeGeneracionDeColumnas <= 0 && columnasActivasActualmente < columnasActivasMaximas) {
			ponerNube ();
			tiempoDeGeneracionDeColumnas = tiempoFijoDeGeneracionDeColumnas;

		}
	}

	void ponerNube ()
	{
		//de primeras que cree una posicion para la nube
		posicionInicialColumna = new Vector3 (7f, Random.Range (alturaMinima, alturaMaxima), -1f);
		//poner una como activa
		columnasActivasActualmente += 1f;

		//se genera una nube y se inician variables de control.
		columna = (GameObject)Instantiate (columna, posicionInicialColumna, Quaternion.identity);
		//se guarda la nube en una matriz
		columnasGuardadas.Add (columna);

	}

	public void pararColumnas ()
	{
		for (int i = 0; i < columnasActivasActualmente; i++) {
			GameObject clon = columnasGuardadas [i];
			columna2d = clon.GetComponent<Rigidbody2D> ();
			columna2d.velocity = new Vector2 (0, 0);
		}
		columnasActivasMaximas = 0;
	}
}
