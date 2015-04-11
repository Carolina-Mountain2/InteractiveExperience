using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
		public bool paused = false;
		public static Pause S;
		MouseLook MouseLookScriptX;
		MouseLook MouseLookScriptY;
		string feedback;
	    string ans;
		bool eval = false;
		int ranQuest = 0;
		public int questPoint = 0;
		public int damage = 3;
	public Question quest;

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
					mouseStopped(true);
					quest = MainScript.S.questions[ranQuest];

				if (quest.type== Question.qType.multiChoice){
						
				GUI.Box (new Rect (285, 80, 550, 250), quest.qText +"\n" +
				         							"A "+ quest.answers[0]+"\n" + 
				         							"B "+ quest.answers[1]+"\n" + 
				         							"C "+ quest.answers[2]+"\n" +         
				         							"D "+ quest.answers[3]+"\n" + 
				         							feedback);
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
						if (GUI.Button (new Rect (305, 320, 100, 50), "A")) {//currently representing correct choice
								//questPoint = questPoint + 100;
								
								feedback = "";
					            ans = "0";
								print (questPoint);
								eval = true;
								//togglePause (false);
								//mouseStart (true);
						}
						if (GUI.Button (new Rect (425, 320, 100, 50), "B")) {//currently representing wrong choice
								//questPoint = questPoint - 25;
								//feedback = "\n Try Again";
								//print ("incorrect");
								ans = "1";
								print (questPoint);
								eval = true;
								//togglePause (false);

						}

						
							if (GUI.Button (new Rect (545, 320, 100, 50), "C")) {//currently representing wrong choice
								//questPoint = questPoint - 25;
								//feedback = "\n Try Again";
								//print ("incorrect");
							     ans = "2";
								 print (questPoint);
					             eval = true;
								//togglePause (false);
				
							}
							if (GUI.Button (new Rect (665, 320, 100, 50), "D")) {//currently representing wrong choice
								//questPoint = questPoint - 25;
								//feedback = "\n Try Again";
								//print ("incorrect");
								ans="3";
								print (questPoint);
					            eval = true;
								//togglePause (false);
				
							}

				if (ans == quest.corChoice.ToString()&& eval == true){
					questPoint = questPoint + 100;
					togglePause (false);
					mouseStart (true);
					print (questPoint);
					eval = false;
					feedback = "";

				}
				if (ans != quest.corChoice.ToString() && eval == true){
					questPoint = questPoint - 25;
					feedback = "\n Try Again";
					print ("incorrect");
					print (questPoint);
					eval = false;

				}
					

					}
			if (quest.type == Question.qType.truefalse){

				GUI.Box (new Rect (285, 80, 550, 250), quest.qText + feedback);
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
				if (GUI.Button (new Rect (425, 320, 100, 50), "True")) {//currently representing correct choice
					ans = "0";
					eval = true;
					//feedback = "";
					print (questPoint);
					//togglePause (false);
					//mouseStart (true);
				}
				if (GUI.Button (new Rect (545, 320, 100, 50), "False")) {//currently representing wrong choice
					ans = "1";
					eval = true;
					//questPoint = questPoint - 25;
					//feedback = "\n Try Again";
					//print ("incorrect");
					print (questPoint);
					//togglePause (false);
					
				}

				if (ans == quest.corChoice.ToString()&& eval == true){
					questPoint = questPoint + 100;
					togglePause (false);
					mouseStart (true);
					print (questPoint);
					eval = false;
					feedback = "";
					
				}
				if (ans != quest.corChoice.ToString() && eval == true){
					questPoint = questPoint - 25;
					feedback = "\n Try Again";
					print ("incorrect");
					print (questPoint);
					eval = false;
					
				}



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