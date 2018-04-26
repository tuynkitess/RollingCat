using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class controladorBoton : MonoBehaviour
{

	//cambiar o no de fondo
	public  int numeroFondo = 0;
	public GameObject fondoAzul;
	public GameObject fondoNaranja;
	public GameObject fondoOscuro;

	public Text puntuMax;
	int p = 0;

	void Start() {
		
		numeroFondo = PlayerPrefs.GetInt ("ValorFondo");
		puntuMax.enabled = false;
		}
	public void click ()
	{
	
		SceneManager.LoadScene (1);
		PlayerPrefs.SetInt ("ValorFondo", numeroFondo);

	}

	public void clickPuntuacion(){
	
		/*p = PlayerPrefs.GetInt ("Score");
		puntuMax.text = p.ToString;
		puntuMax.enabled = true;*/
	}

	public void cambiarFondo ()
	{
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

	}

	public void cambiarFondoClick ()
	{
		switch (numeroFondo) {
		case 0:		
			numeroFondo = 1;
			break;
		case 1: 
			numeroFondo = 2;
			break;
		case 2:
			numeroFondo = 0;
			break;
		}

	
	}

	void Update ()
	{
		
		cambiarFondo ();
	}
}
