using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public GameObject text;
	bool goBack = false;
	bool isActive = true;

	void Awake () {
		text = GameObject.Find("menuText");
	}

	void Start () {
		text.guiText.text = "The Carolina Mountain River Ride";
		}

	void OnGUI ()
	{

		if (goBack == true) {
						if (GUI.Button (new Rect (480, 380, 100, 50), "Return")) {
				Application.LoadLevel ("_Scene_0");

						}
				}


		if (isActive) {
						if (GUI.Button (new Rect (480, 320, 100, 50), "How to Play")) {
								text.guiText.text = "Use your mouse to look around. \n Left click to make selection. \n W is ↑, A is ←, S is ↓, and D is →";
								print ("here's how to play");
								goBack = true;
								isActive = false;
						
						}

						if (GUI.Button (new Rect (480, 390, 100, 50), "Credits")) {
				text.guiText.text = "Programmers: \n \n Person 1, Person 2 \n Person 3, Person 4 \n \n Information Consultant:\n \n Person 5";
				goBack = true;
				isActive = false;
								print ("These people are cool...and not paid");
			
						}


						if (GUI.Button (new Rect (480, 460, 100, 50), "Click to Begin!")) {

								Application.LoadLevel ("_Scene_1");
				
						}
				}

	}

	 


}
