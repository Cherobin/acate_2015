using UnityEngine;
using System.Collections;

public class Splash_Actor : MonoBehaviour {

	public Vector2 direction;
	public int state = 0;
	public float counter = 3.5f;
	Rigidbody2D rb;
	Controle_Disparo controleDisparo;
	Animator animator;
	Animator animator2;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		animator2 = transform.GetChild(0).gameObject.GetComponent<Animator>();
		controleDisparo = GetComponent<Controle_Disparo>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
		case 0:
		{
			FirstAction();
		}
			break;
		case 1:
		{
			SecondAction();
		}
			break;
		case 2:
		{
			ThirdAction();
		}
			break;
		case 3:
		{
			FourthAction();
		}
			break;
		case 4:
		{
			FifthAction();
		}
			break;
		}
	}

	void decideDirection(){
		float x = rb.velocity.x;
		float y = rb.velocity.y;
		animator.SetBool("Up",false);
		animator.SetBool("Right",false);
		animator.SetBool("Down",false);
		animator.SetBool("Left",false);
		animator2.SetBool("ShotUp",false);
		animator2.SetBool("ShotRight",false);
		animator2.SetBool("ShotDown",false);
		animator2.SetBool("ShotLeft",false);
		if(x==0&&y==0){
			return;
		}
		if(y>0){
			//up
			if(x>0){
				//right
				if(x>y){
					animator.SetBool("Right",true);
					animator2.SetBool("ShotRight",true);
					controleDisparo.adjustShotStart = Vector3.zero;
				}else{
					animator.SetBool("Up",true);
					animator2.SetBool("ShotUp",true);
					controleDisparo.adjustShotStart = new Vector3(-0.3f,0,0);
				}
			}else{
				//left
				if(-x>y){
					animator.SetBool("Left",true);
					animator2.SetBool("ShotLeft",true);
					controleDisparo.adjustShotStart = Vector3.zero;
				}else{
					animator.SetBool("Up",true);
					animator2.SetBool("ShotUp",true);
					controleDisparo.adjustShotStart = new Vector3(-0.3f,0,0);
				}
			}
		}else{
			//down
			if(x>0){
				//right
				if(x>-y){
					animator.SetBool("Right",true);
					animator2.SetBool("ShotRight",true);
					controleDisparo.adjustShotStart = Vector3.zero;
				}else{
					animator.SetBool("Down",true);
					animator2.SetBool("ShotDown",true);
					controleDisparo.adjustShotStart = new Vector3(0.3f,0,0);
				}
			}else{
				//left
				if(-x>-y){
					animator.SetBool("Left",true);
					animator2.SetBool("ShotLeft",true);
					controleDisparo.adjustShotStart = Vector3.zero;
				}else{
					animator.SetBool("Down",true);
					animator2.SetBool("ShotDown",true);
					controleDisparo.adjustShotStart = new Vector3(0.3f,0,0);
				}
			}
		}
	}

	
	void FirstAction(){
		counter -= Time.deltaTime;
		rb.velocity = direction;
		decideDirection();
		if(counter<0){
			counter = 2f;
			state = 1;
		}
	}
	
	void SecondAction(){
		
		counter -= Time.deltaTime;
		controleDisparo.canShot = true;
		controleDisparo.multiShot = 5;
		if(counter<0){
			counter = 3;
			state = 2;
		}
	}
	
	void ThirdAction(){
		counter -= Time.deltaTime;
		rb.velocity = -Vector2.up;
		controleDisparo.canShot = true;
		controleDisparo.multiShot = 5;
		decideDirection();
		if(counter<0){
			counter = 2;
			state = 3;
		}
		
	}
	
	void FourthAction(){
		
		counter -= Time.deltaTime;
		rb.velocity = -Vector2.up*5;
		decideDirection();
		if(counter<0){
			counter = 2;
			state = 4;
		}
	}
	
	void FifthAction(){
		Application.LoadLevel("battle");
	}
}
