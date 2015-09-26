using UnityEngine;
using System.Collections;

public class Bonus_dist_shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.velocidadeTiro>550){
				cp.velocidadeTiro = 600;
			}else{
				cp.velocidadeTiro += 50;
			}
			Destroy(this.gameObject);
		}
	}
}
