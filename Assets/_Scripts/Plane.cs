﻿using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){    
		print (col.name);
		if (col.tag == "Boat") {
			print ("Boat hit plane");	
		}
	}
}
