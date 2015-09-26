using UnityEngine;
using System.Collections;

public class Box_Behavior : MonoBehaviour {

	public GameObject prize;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(rb.velocity.x<-1){
			rb.velocity += Vector2.right* 5 * Time.deltaTime;
		}else if(rb.velocity.x>1){
			rb.velocity -= Vector2.right* 5 * Time.deltaTime;
		}else{
			rb.velocity = new Vector2(0,rb.velocity.y);
		}
		if(rb.velocity.y<-1){
			rb.velocity += Vector2.up * 5 * Time.deltaTime;
		}else if(rb.velocity.y>1){
			rb.velocity -= Vector2.up * 5 * Time.deltaTime;
		}else{
			rb.velocity = new Vector2(rb.velocity.x,0);
		}
	}

	public void dropPrize(){
		Destroy(this.gameObject);
		if(prize!=null){
			Instantiate(prize,this.gameObject.transform.position,this.gameObject.transform.rotation);
		}
	}
}
