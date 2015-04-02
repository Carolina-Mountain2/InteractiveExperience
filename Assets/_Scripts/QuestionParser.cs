using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionParser : MonoBehaviour {
	public PT_XMLReader xmlr;
	public PT_XMLHashtable xml;
	public QuestionParser s;
	public Question q;



	// Use this for initialization
	void Start () {
		s = this;

	 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public string removeFormat(string x){    

	
		x = x.Replace ("_", " ");
		//print (x);

		return x;

	
	}
	public int parseAns(string ans){
		int x = -1;
		for (int i = 0; i <= 4; i++) {
			if (i.ToString() == ans){
				//print (i);
				x=i;
			}

		}
		return (x);
	}

	public void read(string xmlText){

		xmlr = new PT_XMLReader ();
		xmlr.Parse (xmlText);
		xml = xmlr.xml ["xml"] [0];
		qtem qt;
		PT_XMLHashList qs = xml ["question"];
		//print (qs.Count);
		for (int i = 0; i < qs.Count; i++) {
			qt = new qtem();
			qt.qid = qs[i].att ("id");
			qt.qtype = qs[i].att ("type");// get type
			qt.qtext = qs[i].att ("text");
			qt.qtext = removeFormat(qt.qtext);
			qt.cChoice = qs[i].att ("correct");
			qt.ansReal = parseAns(qt.cChoice);
			//print (qt.ansReal);

			//print (qt.qid);
			//print (qt.qtype);
			//print (qt.qtext);
			if (qt.qtype == "multichoice"){
				qt.ansarray = new string[4];

				qt.ans = qs[i].att ("a1");
				qt.ans = removeFormat(qt.ans);
				qt.ansarray[0] = qt.ans;

				qt.ans = qs[i].att ("a2");
				qt.ans = removeFormat(qt.ans);
				qt.ansarray[1] = qt.ans;

				qt.ans = qs[i].att ("a3");
				qt.ans = removeFormat(qt.ans);
				qt.ansarray[2] = qt.ans;

				qt.ans = qs[i].att ("a4");
				qt.ans = removeFormat(qt.ans);
				qt.ansarray[3] = qt.ans;
				//print (qt.ans);
				

				//print ( qs[i].att ("text"));

			}


			if (qt.qtype == "truefalse"){
				//print ("deeerp");
				qt.ansarray = new string[2];
				qt.ansarray[0]= "true";
				qt.ansarray[1]="false";

			}


			q = new Question();
		    q.create(qt.qid,qt.qtext,qt.qtype,qt.ansarray,qt.ansReal);
			MainScript.S.Qs.Add(q);

		
		}






	}
}
public class qtem{
	public string qtext;
	public string ans;
	public string qid;
	public string cChoice;
	public string qtype;
	public string[] ansarray;
	public int ansReal;


}
