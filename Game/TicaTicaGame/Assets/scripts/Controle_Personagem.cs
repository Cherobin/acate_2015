using UnityEngine;
using System.Collections;

public class Controle_Personagem : MonoBehaviour {

	public class ColorxLife
	{
		public int color;
		public int life;
	}

	public float speed;
	public int number;
	Rigidbody2D body;
	private Controle_Disparo controleDisparo;
	Animator animator;
	
	public ArrayList vida = new ArrayList();
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		controleDisparo = GetComponent<Controle_Disparo>();
		animator = GetComponent<Animator>();
		controleDisparo.user = number;
		ColorxLife ml = new ColorxLife();
		ml.color = number;
		ml.life = 100;
		vida.Add(ml);
		GameControl.playersList.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		body.velocity *= 0.9f;

		switch(number){
		case 1 :
			ControlPlayer1();
			break;
		case 2:
			ControlPlayer2();
			break;
		}
		decideDirection();
	}

	void decideDirection(){
		float x = body.velocity.x;
		float y = body.velocity.y;
		animator.SetBool("Up",false);
		animator.SetBool("Right",false);
		animator.SetBool("Down",false);
		animator.SetBool("Left",false);
		if(x==0&&y==0){
			return;
		}
		if(y>0){
			//up
			if(x>0){
				//right
				if(x>y){
					animator.SetBool("Right",true);
				}else{
					animator.SetBool("Up",true);
				}
			}else{
				//left
				if(-x>y){
					animator.SetBool("Left",true);
				}else{
					animator.SetBool("Up",true);
				}
			}
		}else{
			//down
			if(x>0){
				//right
				if(x>-y){
					animator.SetBool("Right",true);
				}else{
					animator.SetBool("Down",true);
				}
			}else{
				//left
				if(-x>-y){
					animator.SetBool("Left",true);
				}else{
					animator.SetBool("Down",true);
				}
			}
		}
	}

	public bool takeHit(int color){
		((ColorxLife)vida[0]).life -= 10;
		for(int i = 1;i<vida.Count;i++){
			if(color == ((ColorxLife)vida[i]).color){
				((ColorxLife)vida[i]).life += 10;
				if(((ColorxLife)vida[i]).life>((ColorxLife)vida[0]).life){
					vida = new ArrayList();
					ColorxLife mylife = new ColorxLife();
					mylife.color = color;
					mylife.life = 100;
					vida.Add(mylife);
					return true;
				}else{
					return false;
				}
			}
		}
		ColorxLife ml = new ColorxLife();
		ml.color = color;
		ml.life = 10;
		vida.Add(ml);
		return false;
	}
	
	void ControlPlayer1(){

		
		body.AddForce(Input.GetAxis("VerticalJ")*Vector2.up*speed);
		body.AddForce(Input.GetAxis("HorizontalJ")*Vector2.right*speed);
		if(body.velocity!=Vector2.zero){
			controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
		}

		if(Input.GetKey(KeyCode.JoystickButton1)){
			controleDisparo.canShot = true;
		}
	}
	
	void ControlPlayer2(){

		if(Input.GetKey(KeyCode.A)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.D)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.W)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.S)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Space)){
			controleDisparo.canShot = true;
		}
	}
	void SetShotDirection(){
		controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
	}
}
