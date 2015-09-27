using UnityEngine;
using System.Collections;

public class Jumpy : MonoBehaviour {

	float count;
	public float jump = 20;
	// Use this for initialization
	void Start () {
		count = Random.Range(0,3);
	}
	
	// Update is called once per frame
	void Update () {
		count-=Time.deltaTime;
		if(count<0){
			count = Random.Range(0,3);
			GetComponent<Rigidbody2D>().velocity = Vector2.up*count;
			Controle_Disparo cd = GetComponent<Controle_Disparo>();
			if(cd!=null){
				cd.canShot = true;
				cd.multiShot = (int)Random.Range(1,6);
				cd.velocidadeTiro = (int)Random.Range(200,500);
			}
		}
	}
}
