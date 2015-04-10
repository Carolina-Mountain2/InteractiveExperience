using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
		public bool paused = false;
		public static Pause S;

		void Start () {
				S = this;
				togglePause (false);
		}

		void Update () {

		}

		void OnGUI ()
		{

				if (paused) {
						GUILayout.Box (MainScript.S.questions [0].qText);
		
						if (GUI.Button (new Rect (280, 200, 100, 50), "unpause me!")) {       
								print ("game unpaused");
								togglePause (false);
				                GameObject x = GameObject.Find("First Person Controller");
				               

						}
				}
	}

		public void togglePause (bool isPaused)
		{

				if (isPaused == true) {
						paused = true;
						Time.timeScale = 0f;
						print ("game paused");
						
			            GameObject x = GameObject.Find("First Person Controller");
			           

				} else {
						paused = false;
						Time.timeScale = 1f; 
						print ("game paused");

				}

		}
}