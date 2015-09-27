using UnityEngine;
using System.Collections;

public class CancelFatherRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position,new Vector3(0,0,1),-transform.rotation.eulerAngles.z);
	}
}
