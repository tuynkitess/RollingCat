using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorJuego : MonoBehaviour {

	public static controladorJuego instancia;
	public Text scoreTexto;
	int score = 0;
	// Use this for initialization
	void Start () {
		if (instancia == null) {
			instancia = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void scored(){
		score += 1;
		scoreTexto.text = "Score: " + score;
	}
}
