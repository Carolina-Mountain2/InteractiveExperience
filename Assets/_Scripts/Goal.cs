﻿using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){    
		if (col.tag == "Boat") {
			MainScript.S.gameFinish = true;
			Pause.S.mouseStopped (true);
		}
	}

}
