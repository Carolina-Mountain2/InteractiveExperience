using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {
	public TextAsset xml;  
	QuestionParser QP;
	public static MainScript S;
	public List<Question> Qs;
	public Question[] questions;



	// Use this for initialization
	void Start () {
		S = this;

		QP = GetComponent<QuestionParser> ();  
		Qs = new List<Question>();



		parseQuestions ();
		questions = Qs.ToArray();


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
