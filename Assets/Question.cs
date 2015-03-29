using UnityEngine;
using System.Collections;

public class Question {
	public string qText;
	public enum qType{
		truefalse,
		multiChoice
	}
	public qType type;
	public string[] answers;
	public string QID;
	public string correct;
	public int corChoice;

	// Use this for initialization
	public void create(string id, string qtext, string type ,string[] qanswers,string cchoice)
	{
		this.qText = qtext;
		if (type == "truefalse") {
			this.type = qType.truefalse;
			this.answers = new string[2];
			answers[0] = "true";
			answers[1] = "false";
			this.QID = id;
			this.correct = cchoice;


		}
		else if (type == "multichoice"){
			this.type = qType.multiChoice;
			this.answers = new string[qanswers.Length];
			this.answers = qanswers;
			this.QID = id;
			this.correct = cchoice;
		}
	

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
