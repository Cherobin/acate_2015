using UnityEngine;
using System.Collections;

public class Controle_Arma_Fixa : MonoBehaviour {

	Controle_Disparo controle_disparo;
	public float direction;
	// Use this for initialization
	void Start () {
		controle_disparo = GetComponent<Controle_Disparo>();
		controle_disparo.shotDirection = -direction/180*Mathf.PI;
	}
	
	// Update is called once per frame
	void Update () {
		if(controle_disparo.user!=0){
			controle_disparo.canShot = true;
		}
	}
}
