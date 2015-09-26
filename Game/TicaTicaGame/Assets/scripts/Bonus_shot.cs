using UnityEngine;
using System.Collections;

public class Bonus_shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.multiShot>4){
				cp.multiShot = 5;
			}else{
				cp.multiShot++;
			}
			Destroy(this.gameObject);
		}
	}
}
