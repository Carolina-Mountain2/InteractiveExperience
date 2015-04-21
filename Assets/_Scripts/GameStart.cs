using UnityEngine;
using System.Collections;



public class GameStart : MonoBehaviour {

	public GameObject text;
	public GameObject credit;
	bool goBack = false;
	bool isActive = true;
	public AudioSource audioClick;

	void Awake () {
		text = GameObject.Find("menuText");
		credit = GameObject.Find ("creditText");
	}

	void Start () {
		text.guiText.text = "The Carolina Mountain River Ride";
		credit.guiText.text = "";
		}

	void OnGUI ()
	{

				if (goBack == true) {
						if (GUI.Button (new Rect (430, 380, 100, 50), "Return")) {
								DelayedReset (0.1f);
								audioClick.Play ();
						}
				}


				if (isActive) {
						if (GUI.Button (new Rect (430, 320, 100, 50), "How to Play")) {
								text.guiText.text = "Use your mouse to look around." + 
										"\n Left click to make selection." + 
										"\n W is ↑, A is ←, S is ↓, and D is →" +
										"\n \n You can also use your arrow keys:" +
										"\n ↑, ←, ↓, →";
								goBack = true;
								isActive = false;
								audioClick.Play ();

						}

						if (GUI.Button (new Rect (430, 390, 100, 50), "Credits")) {
								text.guiText.text = "Programmers: \n \n Andrew Madden," + 
										" Brendan Mulhern \n Tyler Strickland," + 
										" Andy Thornburg \n \n" + 
										" Information Consultant:\n \n Olivia Bowman";
								credit.guiText.text = "All assets and terrains were obtained\n" + 
													"through Unity's store\n" + 
													" https://www.assetstore.unity3d.com/en/?gclid=CLnjjO-_h8UCFczm7AodyXAARA#!/content/6 -terrain\n" + 
													" https://www.assetstore.unity3d.com/en/?gclid=CLnjjO-_h8UCFczm7AodyXAARA#!/content/780   -boat";

								goBack = true;
								isActive = false;
								audioClick.Play ();
						}


						if (GUI.Button (new Rect (430, 460, 100, 50), "Click to Begin!")) {

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
