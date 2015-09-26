using UnityEngine;
using System.Collections;

public class Onus_dist_shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			cp.velocidadeTiro -= 50;
			if(cp.velocidadeTiro<250){
				cp.velocidadeTiro = 200;
			}
			Destroy(this.gameObject);
		}
	}
}
