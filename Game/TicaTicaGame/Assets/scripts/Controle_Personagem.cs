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
	 
	public GameObject cores;
	public ArrayList vida = new ArrayList();
	public GameObject tiroPinta;

	public AudioClip convertido;
	public AudioClip somAtira;

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

	GameObject getCorrectPlayer(int color){
		for(int i = 0; i< GameControl.playersList.Count;i++){
			if(((GameObject)GameControl.playersList[i]).GetComponent<Controle_Personagem>().number==color){
				return (GameObject)GameControl.playersList[i];
			}
		}
		return null;
	}

	public bool takeHit(int color){


		float auxX = transform.position.x + UnityEngine.Random.Range((float)-0.3, (float)0.3);
		float auxY = transform.position.y + UnityEngine.Random.Range((float)-0.3, (float)0.3);


		GameObject tinta = (GameObject) Instantiate ( tiroPinta, new Vector3((auxX) , (auxY), transform.position.z), Quaternion.identity);



		  

		tinta.GetComponent<SpriteRenderer>().color = (getCorrectPlayer(color)).GetComponent<SpriteRenderer>().color;
		
		tinta.transform.parent = cores.transform;

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
					AudioSource.PlayClipAtPoint(convertido, transform.position);


					foreach (Transform childTransform in cores.transform) Destroy(childTransform.gameObject);					 
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

		/*if(Input.GetKey(KeyCode.Joystick1Button13)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick1Button15)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick1Button12)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick1Button14)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}*/

		body.AddForce(Input.GetAxis("Vertical1")*Vector2.up*speed);
		body.AddForce(Input.GetAxis("Horizontal1")*Vector2.right*speed);
		if(body.velocity!=Vector2.zero){
			controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
		}
		
		if(Input.GetKey(KeyCode.Joystick1Button2)||Input.GetKey(KeyCode.Joystick1Button1)||Input.GetKey(KeyCode.Joystick1Button3)||Input.GetKey(KeyCode.Joystick1Button0)){
			controleDisparo.canShot = true;
			if(UnityEngine.Random.Range(0, 10)>8)
				AudioSource.PlayClipAtPoint(somAtira, transform.position);
		}


	/*	body.AddForce(Input.GetAxis("Vertical")*Vector2.up*speed);
		body.AddForce(Input.GetAxis("HorizontalJ")*Vector2.right*speed);
		if(body.velocity!=Vector2.zero){
			controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
		}

		if(Input.GetKey(KeyCode.JoystickButton1)){
			controleDisparo.canShot = true;
		}


		if(Input.GetKey(Input.GetJoystickNames()[i].TrimStart 	)){
			controleDisparo.canShot = true;
		}
*/
	}
	
	void ControlPlayer2(){
		/*body.AddForce(Input.GetAxis("Vertical2")*Vector2.up*speed);
		if(Input.GetKey(KeyCode.Joystick2Button13)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
	
		if(Input.GetKey(KeyCode.Joystick2Button15)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}

		if(Input.GetKey(KeyCode.Joystick2Button12)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}

		if(Input.GetKey(KeyCode.Joystick2Button14)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}*/

		body.AddForce(-Input.GetAxis("Vertical2")*Vector2.up*speed);
		body.AddForce(Input.GetAxis("Horizontal2")*Vector2.right*speed);
		if(body.velocity!=Vector2.zero){
			controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
		}
		
		if(Input.GetKey(KeyCode.Joystick2Button2)||Input.GetKey(KeyCode.Joystick2Button1)||Input.GetKey(KeyCode.Joystick2Button3)||Input.GetKey(KeyCode.Joystick2Button0)){
			controleDisparo.canShot = true;
			if(UnityEngine.Random.Range(0, 10)>8)
				AudioSource.PlayClipAtPoint(somAtira, transform.position);;
		}
	}

	void ControlPlayer3(){
		/*
		if(Input.GetKey(KeyCode.Joystick3Button13)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick3Button15)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick3Button12)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick3Button14)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}*/

		body.AddForce(-Input.GetAxis("Vertical3")*Vector2.up*speed);
		body.AddForce(Input.GetAxis("Horizontal3")*Vector2.right*speed);
		if(body.velocity!=Vector2.zero){
			controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
		}

		if(Input.GetKey(KeyCode.Joystick3Button2)||Input.GetKey(KeyCode.Joystick3Button1)||Input.GetKey(KeyCode.Joystick3Button3)||Input.GetKey(KeyCode.Joystick3Button0)){
			controleDisparo.canShot = true;
			if(UnityEngine.Random.Range(0, 10)>8)
				AudioSource.PlayClipAtPoint(somAtira, transform.position);
		}
	}
	
	void ControlPlayer4(){
		/*if(Input.GetKey(KeyCode.Joystick4Button13)){
			body.AddForce(Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick4Button15)){
			body.AddForce(-Vector2.right*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick4Button12)){
			body.AddForce(Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}
		
		if(Input.GetKey(KeyCode.Joystick4Button14)){
			body.AddForce(-Vector2.up*speed);
			if(body.velocity!=Vector2.zero){
				SetShotDirection();
			}
		}*/

		body.AddForce(-Input.GetAxis("Vertical4")*Vector2.up*speed);
		body.AddForce(Input.GetAxis("Horizontal4")*Vector2.right*speed);
		if(body.velocity!=Vector2.zero){
			controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
		}
		
		if(Input.GetKey(KeyCode.Joystick4Button2)||Input.GetKey(KeyCode.Joystick4Button1)||Input.GetKey(KeyCode.Joystick4Button3)||Input.GetKey(KeyCode.Joystick4Button0)){
			controleDisparo.canShot = true;
			if(UnityEngine.Random.Range(0, 10)>8)
				AudioSource.PlayClipAtPoint(somAtira, transform.position);
		}
	}

	void SetShotDirection(){
		controleDisparo.shotDirection = Mathf.Atan2(body.velocity.y,body.velocity.x);
	}
}
