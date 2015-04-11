using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
		public bool paused = false;
		public static Pause S;
		MouseLook MouseLookScriptX;
		MouseLook MouseLookScriptY;
		string feedback;
		int ranQuest = 0;
		public int questPoint = 0;
		public int damage = 3;

		void Start () {
				S = this;
				togglePause (false);
				GameObject x = GameObject.Find ("First Person Controller");
				GameObject y = GameObject.Find ("Main Camera");
				MouseLookScriptX = x.GetComponent<MouseLook> ();
				MouseLookScriptY = y.GetComponent<MouseLook> ();
		}

		void Update () {

		}

		void OnGUI () {
				GUI.skin.box.wordWrap = true;

				if (paused) {	
						GUI.Box (new Rect (285, 80, 500, 200), MainScript.S.questions [ranQuest].qText + feedback);
						if (GUI.Button (new Rect (165, 150, 100, 50), "I give up")) {//currently representing correct choice
								questPoint = questPoint - 100;
								damage--;
								print (questPoint);
								togglePause (false);
								mouseStart (true);
						}
	
						/*
								 * The new Rect for the below Buttons, when script is added
								 * to make multiple choice, 280 is left most, add 100 to that
								 * number to account width, then add 20 to create a nice space
								 * between the buttons.
								 * 
								 * There needs to be an if-else that checks which type. When
								 * that is done all you'll need to is copy the below script
								 * which represents what a multichoice GUI looks like and add
								 * it to the if multichoice statement.
								 */
						//button controllers
						if (GUI.Button (new Rect (305, 300, 100, 50), "Correct Answer!")) {//currently representing correct choice
								questPoint = questPoint + 100;
								feedback = "";
								print (questPoint);
								togglePause (false);
								mouseStart (true);
						}
						if (GUI.Button (new Rect (425, 300, 100, 50), "incorrect!")) {//currently representing wrong choice
								questPoint = questPoint - 25;
								feedback = "\n Try Again";
								print ("incorrect");
								print (questPoint);
								//togglePause (false);

						}
						if (GUI.Button (new Rect (545, 300, 100, 50), "incorrect!")) {//currently representing wrong choice
								questPoint = questPoint - 25;
								feedback = "\n Try Again";
								print ("incorrect");
								print (questPoint);
								//togglePause (false);
				
						}
						if (GUI.Button (new Rect (665, 300, 100, 50), "incorrect!")) {//currently representing wrong choice
								questPoint = questPoint - 25;
								feedback = "\n Try Again";
								print ("incorrect");
								print (questPoint);
								//togglePause (false);
				
						}


				}
		}

		public void mouseStopped (bool mouseStop) {

				if (mouseStop == true) {
						MouseLookScriptX.enabled = !MouseLookScriptX.enabled;
						MouseLookScriptY.enabled = !MouseLookScriptY.enabled;
				} 

		}

		public void mouseStart (bool mouseGo) {
		
				if (mouseGo == true) {
						MouseLookScriptX.enabled = !MouseLookScriptX.enabled;
						MouseLookScriptY.enabled = !MouseLookScriptY.enabled;
				} 
		
		}

		public void togglePause (bool isPaused) {

				if (isPaused == true) {
						ranQuest = Random.Range (2, 23);
						mouseStopped (true);
						paused = true;
						Time.timeScale = 0f;
						print ("game paused");
					

			           

				} else {
						paused = false;
						Time.timeScale = 1f; 
						print ("game paused");

				}

		}
}