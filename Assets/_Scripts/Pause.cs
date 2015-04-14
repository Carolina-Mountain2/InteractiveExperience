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
		int oldQ = 0;   
		public int questPoint = 0;
		public int damage = 3;
		public Question quest;
		public AudioSource audioClick;
	
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
						mouseStopped (true);
						quest = MainScript.S.questions [ranQuest];

						if (quest.type == Question.qType.multiChoice) {
						
								GUI.Box (new Rect (255, 80, 580, 270), quest.qText + "\n \n" +
										"A) " + quest.answers [0] + "\n" + 
										"B) " + quest.answers [1] + "\n" + 
										"C) " + quest.answers [2] + "\n" + 
										"D) " + quest.answers [3] + "\n" + 
										feedback);
								if (GUI.Button (new Rect (135, 150, 100, 50), "I give up")) {//currently representing forfeiting choice
										feedback = "";//<-- resets "try again" if person gives up
										questPoint = questPoint - 100;
										damage--;
										togglePause (false);
										mouseStart (true);
										audioClick.Play ();
								}
	
								//button controllers
								if (GUI.Button (new Rect (315, 360, 100, 50), "A")) {//currently representing correct choice
										//questPoint = questPoint + 100;
										feedback = "";
										ans = "0";
										eval = true;
										audioClick.Play ();
								}
								if (GUI.Button (new Rect (435, 360, 100, 50), "B")) {//currently representing wrong choice
										//questPoint = questPoint - 25;
										//feedback = "\n Try Again";
										//print ("incorrect");
										ans = "1";
										eval = true;
										//togglePause (false);
										audioClick.Play ();

								}

						
								if (GUI.Button (new Rect (555, 360, 100, 50), "C")) {//currently representing wrong choice
										//questPoint = questPoint - 25;
										//feedback = "\n Try Again";
										//print ("incorrect");
										ans = "2";
										eval = true;
										//togglePause (false);
										audioClick.Play ();
				
								}
								if (GUI.Button (new Rect (675, 360, 100, 50), "D")) {//currently representing wrong choice
										//questPoint = questPoint - 25;
										//feedback = "\n Try Again";
										//print ("incorrect");
										ans = "3";
										eval = true;
										//togglePause (false);
										audioClick.Play ();
				
								}

								if (ans == quest.corChoice.ToString () && eval == true) {
										questPoint = questPoint + 100;
										togglePause (false);
										mouseStart (true);
										eval = false;
										feedback = "";
								}
								if (ans != quest.corChoice.ToString () && eval == true) {
										questPoint = questPoint - 25;
										feedback = "\n Try Again";
										eval = false;

								}
					

						}
						if (quest.type == Question.qType.truefalse) {

								GUI.Box (new Rect (285, 80, 580, 270), quest.qText + "\n \n" + feedback);
								if (GUI.Button (new Rect (165, 150, 100, 50), "I give up")) {//currently representing correct choice
									feedback = "";//<-- resets "try again" if person gives up
										questPoint = questPoint - 100;
										damage--;
										togglePause (false);
										mouseStart (true);
										audioClick.Play ();
								}
								//button controllers
								if (GUI.Button (new Rect (435, 360, 100, 50), "True")) {//currently representing correct choice
										ans = "0";
										eval = true;
										//feedback = "";
										//togglePause (false);
										//mouseStart (true);
										audioClick.Play ();
								}
								if (GUI.Button (new Rect (605, 360, 100, 50), "False")) {//currently representing wrong choice
										ans = "1";
										eval = true;
										audioClick.Play ();
										//questPoint = questPoint - 25;
										//feedback = "\n Try Again";
										//print ("incorrect");
										//togglePause (false);
					
								}

								if (ans == quest.corChoice.ToString () && eval == true) {
										questPoint = questPoint + 100;
										togglePause (false);
										mouseStart (true);
										eval = false;
										feedback = "";
					
								}
								if (ans != quest.corChoice.ToString () && eval == true) {
										questPoint = questPoint - 25;
										feedback = "\n Try Again";
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
						while (ranQuest == oldQ){
						ranQuest = Random.Range (2, 23);
						}
						oldQ = ranQuest;
						mouseStopped (true);
						paused = true;
						Time.timeScale = 0f;
				
				} else {
						paused = false;
						Time.timeScale = 1f; 
				}

		}
}