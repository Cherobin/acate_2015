using UnityEngine;
using System.Collections;

public class SpawnRandomObj : MonoBehaviour {
	
	public GameObject[] drops;
	public Transform[] dropPoints;
	public GameObject box;
	public float dropCoolDown = 10;
	private float dropTimer = 2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		dropTimer -= Time.deltaTime;
		if(dropTimer<0){
			dropTimer = dropCoolDown;
			dropBox();
		}
	}

	void dropBox(){
		Transform pos = dropPoints[Random.Range(0,dropPoints.Length)];
		GameObject boxInstance = (GameObject)Instantiate(box, pos.position, gameObject.transform.rotation);
		boxInstance.GetComponent<Box_Behavior>().prize = drops[Random.Range(0,drops.Length)];
		//TODO effects da box sendo destruida
	}
}
