using UnityEngine;
using System.Collections;

public class GoToNext : MonoBehaviour {

	public string nextScene = "battle";
	public float count = 15;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count -= Time.deltaTime;
		if(count<0){
			Application.LoadLevel(nextScene);
		}
	
	}
}
