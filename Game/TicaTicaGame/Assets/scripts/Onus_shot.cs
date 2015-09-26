using UnityEngine;
using System.Collections;

public class Onus_shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.multiShot < 2){
				cp.multiShot = 1;
			}else{
				cp.multiShot--;
			}
			Destroy(this.gameObject);
		}
	}
}
