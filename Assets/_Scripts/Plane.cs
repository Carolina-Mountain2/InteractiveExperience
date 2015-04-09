using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

	public bool paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){    

		if (col.tag == "Boat") {
			print ("Boat hit plane");
			print (MainScript.S.questions[0].qText);
			bool tem = true;
			Pause.S.togglePause(tem);
		}
	}


}
