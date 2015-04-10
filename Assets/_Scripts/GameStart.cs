using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {



	void OnGUI ()
	{

		if (GUI.Button (new Rect (480, 320, 100, 50), "How to Play")) {
			
			print ("here's how to play");
			
		}

		if (GUI.Button (new Rect (480, 390 , 100, 50), "Credits")) {
			
			print ("These people are cool...and not paid");
			
		}


		if (GUI.Button (new Rect (480, 460, 100, 50), "Click to Begin!")) {

						Application.LoadLevel ("_Scene_1");
				
				}
	}


}
