using UnityEngine;
using System.Collections;

public class Controle_Arma_Movel : MonoBehaviour {

	private Rigidbody2D rigidBody;
	Controle_Disparo controle_disparo;
	Color gray;
	public Vector3 direction;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		controle_disparo = GetComponent<Controle_Disparo>();
		controle_disparo.shotDirection = 0;
		sr = GetComponentInChildren<SpriteRenderer>();
		gray = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
		rigidBody.velocity *= 0.95f;
		if(rigidBody.angularVelocity>0){
			rigidBody.angularVelocity -= 100*Time.deltaTime;
			float ang = transform.rotation.eulerAngles.z/180*Mathf.PI+Mathf.PI;
			controle_disparo.shotDirection = ang;
		}else{
			rigidBody.angularVelocity = 0;
		}

		if(rigidBody.velocity.x == 0 && rigidBody.velocity.y == 0){
			sr.color = gray;
			controle_disparo.user = 0;
		}else{
			if(controle_disparo.user!=0){
				controle_disparo.canShot=true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		rigidBody.angularVelocity =  500;
	
		if (coll.gameObject.tag == "Player"){
			rigidBody.velocity.Normalize();
			rigidBody.velocity = rigidBody.velocity.normalized * 20;

			rigidBody.AddForce(coll.gameObject.GetComponent<Rigidbody2D>().velocity);

			Controle_Disparo cp = coll.gameObject.GetComponent<Controle_Disparo>();
			if(cp.user!= controle_disparo.user){
				sr.color =coll.gameObject.GetComponent<SpriteRenderer>().color;
				controle_disparo.user = coll.gameObject.GetComponent<Controle_Disparo>().user;
			}
		}
		
	}
}
