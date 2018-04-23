using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controladorJuego : MonoBehaviour
{

	//intancia de la propia clase
	public static controladorJuego instancia;

	//controles varios
	public Rigidbody2D gato;
	public GameObject controladorNube;
	public GameObject controladorColumna;

	//control del gato
	public GameObject controlGato;

	//UI para el score y la muerte
	public Text inicioText;
	public Text scoreTexto;
	public Text gameOverText;
	public Text reinicioText;
	float score = 0;

	//juego activo o no
	public bool juegoActivo;
	public bool gatoMuerto;
	bool creadoraColumnas = false;
	bool creadoraNubes = true;

	// Use this for initialization
	void Start ()
	{
		juegoActivo = false;
		if (instancia == null) {
			instancia = this;
		}
		scoreTexto.text = "Score: " + score;
		gameOverText.enabled = false;
		reinicioText.enabled = false;
	}

	//poner a 60 fps el juego
	void Awake ()
	{
		Application.targetFrameRate = 60;
	}

	
	// se controle todo el juego desde aqui
	void Update ()
	{
		//control de si el juego esta iniciado o hay que iniciarlo
		if (!juegoActivo && !gatoMuerto) {
			gato.bodyType = RigidbodyType2D.Static;
			//de juego inactivo a activo
			if (Input.GetMouseButtonDown (0)) {
				juegoActivo = true;
				gato.bodyType = RigidbodyType2D.Dynamic;
				Gato.instancia.gatoVolar ();
				creadoraColumnas = true;
				inicioText.enabled = false;
			}

		} else if (juegoActivo) {
			Gato.instancia.gatoCaidaSuave ();
			//juego activo y hacen tap
			if (Input.GetMouseButtonDown (0)) {
				gato.bodyType = RigidbodyType2D.Dynamic;
				Gato.instancia.gatoVolar ();
				creadoraColumnas = true;
			}

		}

		//update de columnas
		if (creadoraColumnas) {
			creadoraDeColumnas.instancia.creadoraColumnas ();
		}

		//gato muerto, reiniciar
		if (gatoMuerto) {
			//recargar
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene (0);
			}
		}

	}

	public void scored ()
	{
		score += 0.5f;
		scoreTexto.text = "Score: " + score;
	}

	public void muerte ()
	{
		juegoActivo = false;
		gatoMuerto = true;
		creadoraDeColumnas.instancia.pararColumnas ();
		pararSuelos.instancia.parar ();
		//gato.velocity = Vector3.zero;
		gameOverText.enabled = true;
		reinicioText.enabled = true;
	}
}
