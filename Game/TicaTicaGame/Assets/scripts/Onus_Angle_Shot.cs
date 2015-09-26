using UnityEngine;
using System.Collections;

public class Onus_Angle_Shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			cp.multiShotAngleVariation -= 15;
			if(cp.multiShotAngleVariation<10){
				cp.multiShotAngleVariation = 1;
			}
			Destroy(this.gameObject);
		}
	}
}
