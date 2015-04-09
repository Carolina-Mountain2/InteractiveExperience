using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool paused = false;
	public static Pause S;

	void Start(){
		S = this;
		togglePause (false);
	}
	void Update() {

		}

	void OnGui () {
	
		if (paused == true) {
			

			print("game paused");
			
		} 
		
	}



	
	public void togglePause(bool isPaused)
	{
		
		if (isPaused == true) {
			paused = true;
			Time.timeScale = 0;

			print("game paused");
		}
	}
}