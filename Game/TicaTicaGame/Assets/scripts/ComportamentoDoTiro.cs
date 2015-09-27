using UnityEngine;
using System.Collections;

public class ComportamentoDoTiro : MonoBehaviour {

	public int owner;
	public GameObject deathAnimation;
	Rigidbody2D rb;
	float slowestSpeedAllowed = 1;
	SpriteRenderer sr;
	Color color;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		color = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.x<slowestSpeedAllowed&&
		   rb.velocity.x>-slowestSpeedAllowed&&
		   rb.velocity.y<slowestSpeedAllowed&&
		   rb.velocity.y>-slowestSpeedAllowed){
			Explode();
		}else{
			if(rb.velocity.x<0){
				rb.velocity += Vector2.right* 5 * Time.deltaTime;
			}else if(rb.velocity.x>0){
				rb.velocity -= Vector2.right* 5 * Time.deltaTime;
			}
			if(rb.velocity.y<0){
				rb.velocity += Vector2.up * 5 * Time.deltaTime;
			}else if(rb.velocity.y>0){
				rb.velocity -= Vector2.up * 5 * Time.deltaTime;
			}

		}

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Tiro"){
			if(other.GetComponent<SpriteRenderer>().color!=color){
				Explode();
			}
		}else if(other.tag == "Parede"){
			Explode();
			Instantiate(deathAnimation,transform.position,transform.rotation);
		}else if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.user!=owner){
				Explode();
				if(other.GetComponent<Controle_Personagem>().takeHit(owner)){
					other.GetComponent<SpriteRenderer>().color = color;
					other.GetComponent<Controle_Disparo>().user = owner;
				}
			}else{
				GetComponents<CircleCollider2D>()[1].isTrigger = true;
			}
		}else if(other.tag == "ArmaFixa"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.user!=owner){
				Explode();
				Debug.Log("Tirotiro");
				other.GetComponent<SpriteRenderer>().color = color;
				other.GetComponent<Controle_Disparo>().user = owner;
				other.GetComponent<Controle_Arma_Fixa>().timerReset = 10;
			}
		}else if(other.tag == "ArmaMovel"){
			//faz nada
		}else if(other.tag == "Box"){
			Explode();
			other.GetComponent<Box_Behavior>().dropPrize();
		}
	}

	void Explode(){
		GameObject obj = ((GameObject)Instantiate(deathAnimation,transform.position,transform.rotation));
		SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
		if(sr==null){
			sr = obj.GetComponentInChildren<SpriteRenderer>();
		}
		sr.color = color;
		Destroy(this.gameObject);
	}
	
	void OnTriggerExit2D(Collider2D other) {
		Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
		if(cp!=null&&cp.user==owner){
			GetComponents<CircleCollider2D>()[1].isTrigger = false;
		}
	}
}
