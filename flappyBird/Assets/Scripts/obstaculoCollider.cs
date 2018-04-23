using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculoCollider : MonoBehaviour {

	public BoxCollider2D caja;
	int controlSoloUno = 0;
	int score = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Gato>() != null && controlSoloUno ==0)
		{
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			controladorJuego.instancia.scored();
			controlSoloUno +=1;

		}
	}

}
