using UnityEngine;
using System.Collections;

public class Controle_Disparo : MonoBehaviour {
	
	public GameObject tiro;
	public float velocidadeTiro;
	public float frequenciaDeTiro = 1;
	public float distanciaInicial = 1;
	private float tiroCounter = 0;

	public float shotDirection = 0;
	public bool canShot;
	public int multiShot = 2;
	public float multiShotAngleVariation = 360;
	public int user = 0;
	public Vector3 adjustShotStart = Vector3.zero;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(canShot){
			if(tiroCounter<0){
				if(multiShot<=1){
					Vector2 front = new Vector2(Mathf.Cos(shotDirection),Mathf.Sin(shotDirection));
					GameObject instanciadotiro = (GameObject)Instantiate(tiro,transform.position+adjustShotStart+new Vector3(front.x,front.y,0)*distanciaInicial,Quaternion.identity);
					instanciadotiro.GetComponent<ComportamentoDoTiro>().owner = user;
					Rigidbody2D rigidbodyTiro = instanciadotiro.GetComponent<Rigidbody2D>();
					
					rigidbodyTiro.AddForce(front*velocidadeTiro);
					instanciadotiro.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
					tiroCounter += frequenciaDeTiro;
				}else{
					float angleVariation = multiShotAngleVariation/180*Mathf.PI;
					float step = angleVariation/(multiShot-1);
					float startAng = -angleVariation/2;
					for(int i = 0;i<multiShot;i++){
						Vector2 front = new Vector2(Mathf.Cos(shotDirection+startAng+step*i),Mathf.Sin(shotDirection+startAng+step*i));
						GameObject instanciadotiro = (GameObject)Instantiate(tiro,transform.position+new Vector3(front.x,front.y,0)*distanciaInicial,Quaternion.identity);
						instanciadotiro.GetComponent<ComportamentoDoTiro>().owner = user;
						Rigidbody2D rigidbodyTiro = instanciadotiro.GetComponent<Rigidbody2D>();
						
						rigidbodyTiro.AddForce(front*velocidadeTiro);
						SpriteRenderer sr = GetComponent<SpriteRenderer>();
						if(sr==null){
							sr = GetComponentInChildren<SpriteRenderer>();
						}
						instanciadotiro.GetComponent<SpriteRenderer>().color = sr.color;
					}
					tiroCounter += frequenciaDeTiro;
				}
			}else{
				tiroCounter -= Time.deltaTime;
			}

			canShot=false;
		}

	}


}
