﻿using UnityEngine;
using System.Collections;

public class DeleteWhenReady : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DeleteMe(){
		Destroy(this.gameObject);
	}
}
