using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* StatObj is the class used to control & update each player stat
 *
 * To Do:
 * 	- Should players be allowed to make themselves lose by purchasing enough negative items? 
*/

public class StatObj : MonoBehaviour {

	public string stat_name;
	public int default_value;
	public int max_value;
	int curr_value;

	Text text;
	
	void Start () {
		curr_value = default_value;
		text = GetComponent<Text> ();
	}
	
	// Prints "Value"
	void Update () {
		//text.text = "\t" + stat_name + ": " + curr_value;
		text.text = "" + curr_value;
	}

	//Change the value of this stat
	public void addValue(int delta){
		if (curr_value + delta >= getMaxValue ())	//Don't overload
			curr_value = max_value;
	//	else if (curr_value + delta <= 0) {			//Needs to be able to be negative for groceries
	//		curr_value = 0;
	//	}
		else
			curr_value += delta;
	}

	public string getName(){
		return stat_name;
	}

	public int getValue(){
		return curr_value;
	}

	public int getMaxValue(){
		return max_value;
	}
}
