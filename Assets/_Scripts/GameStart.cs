using UnityEngine;
using System.Collections;



public class GameStart : MonoBehaviour {

	public GameObject text;
	bool goBack = false;
	bool isActive = true;
	public AudioSource audioClick;

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
								DelayedReset (0.1f);
								audioClick.Play ();
						}
				}


				if (isActive) {
						if (GUI.Button (new Rect (480, 320, 100, 50), "How to Play")) {
								text.guiText.text = "Use your mouse to look around." + 
										"\n Left click to make selection." + 
										"\n W is ↑, A is ←, S is ↓, and D is →";
								goBack = true;
								isActive = false;
								audioClick.Play ();

						}

						if (GUI.Button (new Rect (480, 390, 100, 50), "Credits")) {
								text.guiText.text = "Programmers: \n \n Andrew Madden," + 
										" Brendan Mulhern \n Tyler Strickland," + 
										" Andy Thornburg \n \n" + 
										" Information Consultant:\n \n Olivia Bowman";
								goBack = true;
								isActive = false;
								audioClick.Play ();
						}


						if (GUI.Button (new Rect (480, 460, 100, 50), "Click to Begin!")) {

								Application.LoadLevel ("__game_scene");
								audioClick.Play ();
						}
				}

		}

	public void DelayedReset (float delay) {
		Invoke ("Reset", delay);
	}
	
	public void Reset() {
		Application.LoadLevel ("__title_screen");
	}

}
