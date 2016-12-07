using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GroceryItem : MonoBehaviour {

	int health_change;
	int sleep_change;
	int family_change;
	int cost;

	public StatObj myHealth;
	public StatObj mySleep;
	public StatObj myFam;

	public Image check;
	Color temp;

	bool inCart = false;

	// Use this for initialization
	void Start () {
		temp = check.color;
	}

	//Values Stored Cost -Family - HP - Happiness
	public void setValues(int val1, int val2, int val3, int val4){
		Debug.Log ("Setting Values");
		cost = val1;
		family_change = val2;
		health_change = val3;
		sleep_change = val4;
	}

	//Add or remove items from cart
	public void onClickMe(){
		//If not in cart, add stat change to each stat
		Debug.Log("Clicked, cost = " + cost + ", " + family_change);

		if (!inCart) {
			mySleep.addValue (sleep_change);
			myHealth.addValue (health_change);
			myFam.addValue (family_change);
			inCart = true;
			temp.a = 255f;
			check.color = temp;
		} else {	//If in cart already,remove & reset stat changes
			myHealth.addValue (-1 * health_change);
			mySleep.addValue (-1 * sleep_change);
			myFam.addValue (-1 * family_change);
			inCart = false;
			temp.a = 0f;
			check.color = temp;
		}
	}


}
