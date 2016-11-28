using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GroceryItem : MonoBehaviour {

	public string stat_name;

	public int health_change = 0;
	public int sleep_change = 0;
	public int family_change = 0;

	public StatObj myHealth;
	public StatObj mySleep;
	public StatObj myFam;

	bool inCart;

	// Use this for initialization
	void Start () {
		inCart = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Add or remove items from cart
	public void onClickMe(){
		//If not in cart, add stat change to each stat
		if (!inCart) {
			myHealth.addValue (health_change);
			mySleep.addValue (sleep_change);
			myFam.addValue (family_change);
			inCart = true;
		} else {	//If in cart already,remove & reset stat changes
			myHealth.addValue (-1 * health_change);
			mySleep.addValue (-1 * sleep_change);
			myFam.addValue (-1 * family_change);
			inCart = false;
		}
	}


}
