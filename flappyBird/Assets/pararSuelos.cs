using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pararSuelos : MonoBehaviour {
    
    public static pararSuelos instancia;
    public Rigidbody2D suelo1;
    public Rigidbody2D suelo2;

	// Use this for initialization
	void Start () {
        if (instancia == null)
        {
            instancia = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void parar(){
        suelo1.velocity = new Vector2(0, 0);
        suelo2.velocity = new Vector2(0, 0);
    }
}
