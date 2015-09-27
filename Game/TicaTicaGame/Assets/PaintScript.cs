using UnityEngine;
using System.Collections;

public class PaintScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Tiro"){
			Color old = GetComponent<SpriteRenderer>().color;
			Color newc = other.gameObject.GetComponent<SpriteRenderer>().color;
			GetComponent<SpriteRenderer>().color = new Color(newc.r*0.1f+old.r*0.9f,newc.g*0.1f+old.g*0.9f,newc.b*0.1f+old.b*0.9f,newc.a*0.1f+old.a*0.9f);
		}
	}
}
