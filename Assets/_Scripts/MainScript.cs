using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {
	public TextAsset xml;  
	QuestionParser QP;
	public static MainScript S; // the singleton for this class
	public List<Question> Qs; // HOUSEKEEPING ONLY: a linked list containing the questions
	public Question[] questions; // the array of questions: use this to retrieve questions



	// Use this for initialization
	void Start () {
		S = this;

		QP = GetComponent<QuestionParser> ();  // the question parser, it should be attached to the same game object as this script
		Qs = new List<Question>();// HOUSEKEEPING ONLY: a linked list containing the questions



		parseQuestions ();
		questions = Qs.ToArray(); // QUESTION ARRAY CREATED HERE; ANYTHING DEALING WITH QUESTIONS SHOULD BE BELOW THIS




		//print (questions [1].correct);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void parseQuestions(){
		//print (xml.text);
		QP.read (xml.text);

	}
}
