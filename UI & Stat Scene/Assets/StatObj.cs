using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatObj : MonoBehaviour {

	public string stat_name;
	public int default_value;
	public int max_value;
	static int curr_value;

	Text text;

	// Use this for initialization
	void Start () {
		curr_value = default_value;

		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "\t" + stat_name + ": " + curr_value;
	}

	//Change the value of this stat
	void addValue(int delta){
		if (curr_value + delta >= getMaxValue ())	//Don't overload
			curr_value = max_value;
		else if (curr_value + delta <= 0) {			//Don't become negative
			curr_value = 0;
		}
		else
			curr_value += delta;
	}

	string getName(){
		return stat_name;
	}

	int getValue(){
		return curr_value;
	}

	int getMaxValue(){
		return max_value;
	}
}
