using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static ArrayList playersList = new ArrayList();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		int winner = checkVictory();
		if(winner!=-1){
			Debug.Log("WE HAVE A WINNER!!!");
			Debug.Log("Congratulations Player"+winner+" !!!");

			for(int i = 0; i< playersList.Count;i++){
				DestroyImmediate((GameObject)playersList[0]);
				playersList.Remove((GameObject)playersList[0]);
			}
			Application.LoadLevel("battle");
		}
	}

	int checkVictory(){
		if(playersList.Count>0){
			int winner = ((GameObject)playersList[0]).GetComponent<Controle_Disparo>().user;
			for(int i = 1; i< playersList.Count;i++){
				if(((GameObject)playersList[i]).GetComponent<Controle_Disparo>().user != winner){
					return -1;
				}
			}
			return winner;
		}else{
			return -1;
		}
	}
}
