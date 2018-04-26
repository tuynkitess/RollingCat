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
	public Button botonReinicio;
	public Button botonMenu;
	float score = 0;

	//juego activo o no
	public bool juegoActivo;
	public bool gatoMuerto;
	bool creadoraColumnas = false;
	bool creadoraNubes = true;

	//cambiar o no de fondo
	public static int numeroFondo = 0;
	public GameObject fondoAzul;
	public GameObject fondoNaranja;
	public GameObject fondoOscuro;

	// Use this for initialization
	void Start ()
	{
		juegoActivo = false;
		if (instancia == null) {
			instancia = this;
		}
		numeroFondo = PlayerPrefs.GetInt ("ValorFondo");
		//poner el fondo elegido
		switch (numeroFondo) {
		case 0:		
			fondoAzul.SetActive (true);
			fondoNaranja.SetActive (false);
			fondoOscuro.SetActive (false);
			break;
		case 1: 
			fondoAzul.SetActive (false);
			fondoNaranja.SetActive (true);
			fondoOscuro.SetActive (false);
			break;
		case 2:
			fondoAzul.SetActive (false);
			fondoNaranja.SetActive (false);
			fondoOscuro.SetActive (true);
			break;
		}
		scoreTexto.text = "Score: " + score;

		//que no se vean textos no necesarios
		gameOverText.enabled = false;
		botonReinicio.enabled = false;
		botonMenu.enabled = false;

		//botones para que no se vean
		botonMenu.transform.position = new Vector2 (0f, -212f);
		botonReinicio.transform.position = new Vector2 (0f, -212f);
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
			/*if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene (1);
			}*/
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
		botonMenu.enabled = true;
		botonReinicio.enabled = true;

		botonMenu.transform.position = new Vector2 (0, 0);
		botonReinicio.transform.position = new Vector2 (0, -1f);

		/*//puntuacion maxima
		if (PlayerPrefs.GetInt ("Score") == 0 || PlayerPrefs.GetInt ("Score") == null) {
		
			PlayerPrefs.SetInt ("Score", (int)score);
		
		} else if (PlayerPrefs.GetInt ("Score") < (int)score) {
		
			PlayerPrefs.SetInt ("Score", (int)score);
		}*/

	}

	public void reiniciarJuego ()
	{
		SceneManager.LoadScene (1);
	}

	public void volverAlMenu ()
	{
		SceneManager.LoadScene (0);
		PlayerPrefs.SetInt ("ValorFondo", numeroFondo);
	}


}
