using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){    
		//print (col.name);
		if (col.tag == "Boat") {
			Pause.S.hitRock = true;
			bool tem = true;
			Pause.S.togglePause(tem);
			Destroy(this);//destroys this rock's collider
		}
	}
}
