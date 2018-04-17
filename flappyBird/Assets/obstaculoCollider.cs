using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculoCollider : MonoBehaviour {

	public BoxCollider2D caja;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<pajaro>() != null)
		{
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			controladorJuego.instancia.scored();
		}
	}

}
