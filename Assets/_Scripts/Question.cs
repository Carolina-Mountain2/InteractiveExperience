using UnityEngine;
using System.Collections;

public class Question {
	public string qText; // the question text itself
	public enum qType{
		truefalse,
		multiChoice
	}
	public qType type;
	public string[] answers; // the answers in an array
	public string QID; // HOUSEKEEPING ONLY: the number of this question
	public string correct; // HOUSEKEEPING ONLY: the string form of the correct answer
	public int corChoice;// the index of the correct answer

	// Use this for initialization
	public void create(string id, string qtext, string type ,string[] qanswers,int cchoice)
	{
		this.qText = qtext;
		if (type == "truefalse") {
			this.type = qType.truefalse;
			this.answers = new string[2];
			answers[0] = "true";
			answers[1] = "false";
			this.QID = id;
			this.corChoice = cchoice;


		}
		else if (type == "multichoice"){
			this.type = qType.multiChoice;
			this.answers = new string[qanswers.Length];
			this.answers = qanswers;
			this.QID = id;
			this.corChoice = cchoice;
		}
	

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
