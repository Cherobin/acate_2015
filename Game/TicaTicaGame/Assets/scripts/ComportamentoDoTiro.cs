using UnityEngine;
using System.Collections;

public class ComportamentoDoTiro : MonoBehaviour {

	public int owner;
	Rigidbody2D rb;
	float slowestSpeedAllowed = 1;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.x<slowestSpeedAllowed&&
		   rb.velocity.x>-slowestSpeedAllowed&&
		   rb.velocity.y<slowestSpeedAllowed&&
		   rb.velocity.y>-slowestSpeedAllowed){
			Destroy(this.gameObject);
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
			if(other.GetComponent<SpriteRenderer>().color!=GetComponent<SpriteRenderer>().color){
				Destroy(this.gameObject);
			}
		}else if(other.tag == "Parede"){
			Destroy(this.gameObject);
		}else if(other.tag == "Player"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.user!=owner){
				Destroy(this.gameObject);
				if(other.GetComponent<Controle_Personagem>().takeHit(owner)){
					other.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
					other.GetComponent<Controle_Disparo>().user = owner;
				}
			}
		}else if(other.tag == "ArmaFixa"){
			Controle_Disparo cp = other.GetComponent<Controle_Disparo>();
			if(cp.user!=owner){
				Destroy(this.gameObject);
				other.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
				other.GetComponent<Controle_Disparo>().user = owner;
			}
		}else if(other.tag == "ArmaMovel"){
			//faz nada
		}else if(other.tag == "Box"){
			Destroy(this.gameObject);
			other.GetComponent<Box_Behavior>().dropPrize();
		}
	}
}
