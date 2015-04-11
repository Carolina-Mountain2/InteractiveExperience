using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
		public bool paused = false;
		public static Pause S;
		MouseLook MouseLookScriptX;
		MouseLook MouseLookScriptY;
		int ranQuest = 0;


		void Start () {
				S = this;
				togglePause (false);
				GameObject x = GameObject.Find("First Person Controller");
				GameObject y = GameObject.Find("Main Camera");
				MouseLookScriptX = x.GetComponent<MouseLook>();
				MouseLookScriptY = y.GetComponent<MouseLook>();

		}

		void Update () {

		}

		void OnGUI () {
			GUI.skin.box.wordWrap = true;
				if (paused) {

						GUI.Box (new Rect (280, 80, 500, 200), MainScript.S.questions [ranQuest].qText);
								if (GUI.Button (new Rect (280, 300, 100, 50), "unpause me!")) {       
								print ("game unpaused");
								togglePause (false);
								MouseLookScriptX.enabled = !MouseLookScriptX.enabled;
								MouseLookScriptY.enabled = !MouseLookScriptY.enabled;

						}
				}
	}

		public void togglePause (bool isPaused)
		{

				if (isPaused == true) {
			ranQuest = Random.Range (2, 23);

						paused = true;
						Time.timeScale = 0f;
						print ("game paused");
						MouseLookScriptX.enabled = !MouseLookScriptX.enabled;
						MouseLookScriptY.enabled = !MouseLookScriptY.enabled;

			           

				} else {
						paused = false;
						Time.timeScale = 1f; 
						print ("game paused");

				}

		}
}