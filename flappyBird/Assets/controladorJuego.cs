using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorJuego : MonoBehaviour {

	public static controladorJuego instancia;
    public Rigidbody2D gato;
    public GameObject controladorNube;
    public GameObject controladorColumna;



	public Text scoreTexto;
	float score = 0;
	// Use this for initialization
	void Start () {
		if (instancia == null) {
			instancia = this;
		}
		scoreTexto.text = "asdf";
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void scored(){
		score +=0.5f;
		scoreTexto.text = "Score: " + score;
	}

    public void muerte() {
        creadoraDeColumnas.instancia.pararColumnas();
        pararSuelos.instancia.parar();
        //gato.velocity = Vector3.zero;
        scoreTexto.text = "Muerto"; 
    }
}
