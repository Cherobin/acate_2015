using UnityEngine;
using System.Collections;

public class LoadWinnerColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = GameControl.lastWinnerColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
