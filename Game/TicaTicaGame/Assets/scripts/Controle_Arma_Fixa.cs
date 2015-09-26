using UnityEngine;
using System.Collections;

public class Controle_Arma_Fixa : MonoBehaviour {

	Controle_Disparo controle_disparo;
	public float direction;
	public float rotationSpeed = 50;
	public float timerReset = 0;
	Color gray;
	// Use this for initialization
	void Start () {
		controle_disparo = GetComponent<Controle_Disparo>();
		gray = GetComponentInChildren<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {

		if(controle_disparo.user!=0){
			controle_disparo.canShot = true;
			timerReset -= Time.deltaTime;
			if(timerReset<=0){
				controle_disparo.user = 0;
				GetComponentInChildren<SpriteRenderer>().color = gray;
			}
		}
		controle_disparo.shotDirection = transform.rotation.eulerAngles.z/180*Mathf.PI-Mathf.PI/2;
		miraInimigoMaisProximo();
	}


	void miraInimigoMaisProximo(){
		GameObject target = getClosestEnemy();
		if(target==null){
			return;//ninguem a vista!
		}
		float anguloEsperado = Mathf.Atan2(target.transform.position.y-transform.position.y, target.transform.position.x-transform.position.x);
		float anguloAtual = transform.rotation.eulerAngles.z/180*Mathf.PI-Mathf.PI/2;
		if(anguloEsperado-anguloAtual>Mathf.PI){
			anguloEsperado -= Mathf.PI*2;
		}
		if(anguloEsperado-anguloAtual<-Mathf.PI){
			anguloEsperado += Mathf.PI*2;
		}
		if(anguloEsperado-anguloAtual>-0.1&&anguloEsperado-anguloAtual<0.1){
			//faz nada
		}else if(anguloEsperado>anguloAtual){
//			Vector3 ang = transform.rotation.eulerAngles;
			//			transform.rotation.eulerAngles.Set(ang.x,ang.y,ang.z+Mathf.PI/2*Time.deltaTime);
			transform.RotateAround(transform.position,new Vector3(0,0,1),rotationSpeed*Time.deltaTime);
		}else{
			transform.RotateAround(transform.position,new Vector3(0,0,1),-rotationSpeed*Time.deltaTime);
//			Vector3 ang = transform.rotation.eulerAngles;
//			transform.rotation.eulerAngles.Set(ang.x,ang.y,ang.z-Mathf.PI/2*Time.deltaTime);
		}
		float anguloNovo = transform.rotation.eulerAngles.z/180*Mathf.PI-Mathf.PI/2;

	}

	GameObject getClosestEnemy(){
		float distance = 999999999999999;
		GameObject closest = null;
		for(int i = 0; i< GameControl.playersList.Count;i++){
			GameObject current = (GameObject)GameControl.playersList[i];
			if(current==null){
				GameControl.playersList.RemoveAt(i);
				i--;
				continue;
			}
			float dis = GetDistanceWeight(current);
			if(dis<distance && !isMyTeam(current)){
				distance = dis;
				closest = current;
			}
		}
		return closest;
	}

	float GetDistanceWeight(GameObject target){
		float x = transform.position.x - target.transform.position.x;
		float y = transform.position.y - target.transform.position.y;
		return x*x+y*y;
	}

	bool isMyTeam(GameObject other){
		return other.GetComponent<Controle_Disparo>().user == GetComponent<Controle_Disparo>().user;
	}
}
