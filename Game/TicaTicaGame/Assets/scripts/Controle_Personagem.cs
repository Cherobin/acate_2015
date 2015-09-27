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
	Animator animator2;
	
	public ArrayList vida = new ArrayList();
	
	// Use this for initialization
	void Start () {
		if(!GameControl.playersOn[number-1]){
			Destroy(this.gameObject);
			return;
		}
		body = GetComponent<Rigidbody2D>();
		controleDisparo = GetComponent<Controle_Disparo>();
		animator = GetComponent<Animator>();
		animator2 = transform.GetChild(0).gameObject.GetComponent<Animator>();
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
		case 3:
			ControlPlayer3();
			break;
		case 4:
			ControlPlayer4();
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

	void ControlPlayer3(){
		
		if(Input.GetKey(KeyCode.Keypad1)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.Keypad3)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.Keypad5)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.Keypad2)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.KeypadEnter)){
			controleDisparo.canShot = true;
		}
	}
	
	void ControlPlayer4(){
		
		if(Input.GetKey(KeyCode.J)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.L)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.I)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		if(Input.GetKey(KeyCode.K)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.RightShift)){
			controleDisparo.canShot = true;
		}
	}

	void SetShotDirection(){
		controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
	}
}
