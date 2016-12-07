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
	bool disabled;
	int isXmas = 0;

	// Use this for initialization
	void Start () {
		temp = check.color;
		checkGifts ();
	}

	//Values Stored Cost -Family - HP - Happiness
	public void setValues(int val1, int val2, int val3, int val4){
		Debug.Log ("Setting Values");
		cost = val1;
		family_change = val2;
		health_change = val3;
		sleep_change = val4;
	}

	public void setXmas(int x){
		isXmas = x;
		if (isXmas == 3)
			checkGifts ();
	}

	//Add or remove items from cart
	public void onClickMe(){

		if (disabled)
			return;

		//Disables xmas gifts before thursday & friday
		if (isXmas != 0 && GameManager.Instance.getLevel() < 4) {
			return;
		}
			
		//If not in cart, add stat change to each stat
		if (!inCart) {
			mySleep.addValue (sleep_change);
			myHealth.addValue (health_change);
			myFam.addValue (family_change);
			inCart = true;
			temp.a = 255f;
			check.color = temp;
			setXmasStatus(true);
		} else {	//If in cart already,remove & reset stat changes
			myHealth.addValue (-1 * health_change);
			mySleep.addValue (-1 * sleep_change);
			myFam.addValue (-1 * family_change);
			inCart = false;
			temp.a = 0f;
			check.color = temp;
			setXmasStatus (false);
		}
	}

	public void checkGifts(){
		//Checks off bought gifts & disables them
		Debug.Log (isXmas);
		Debug.Log (GameManager.Instance.gift3);
		if ((isXmas == 1 && GameManager.Instance.gift1) ||
			(isXmas == 2 && GameManager.Instance.gift2) ||
			(isXmas == 3 && GameManager.Instance.gift3)) 
		{	Debug.Log (gameObject.name);
			temp.a = 255f;
			check.color = temp;
			disabled = true;		}
		if (isXmas == 3 && GameManager.Instance.gift3) 
		{	Debug.Log (gameObject.name);
			temp.a = 255f;
			check.color = temp;
			disabled = true;		}
	}

	//Update game manager xmas stat as added & removed from cart
	public void setXmasStatus(bool status){
		if (disabled)
			return;
		if (isXmas == 1)
			GameManager.Instance.setGift1(status);
		if (isXmas == 2)
			GameManager.Instance.setGift2(status);
		if (isXmas == 3) {
			GameManager.Instance.setGift3 (status);
			Debug.Log ("Set status to: " + status);
		}
	}

}
