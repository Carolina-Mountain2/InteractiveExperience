using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

	public bool paused = false;
	public GameObject            qText;
	// Use this for initialization
	void Start () {
		//qText = GameObject.Find("questionText"); <-- in case GUI Box is inadequate

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){    

		if (col.tag == "Boat") {
			bool tem = true;
			Pause.S.togglePause(tem);
			Destroy(this);//destroy this plane's collider
		}
	}


}
