using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroceryManager : MonoBehaviour {

	public RawImage placeholder;
	public Texture[] backDrops = new Texture[5];

	public GroceryItem Check1;
	public GroceryItem Check2;
	public GroceryItem Check3;
	public GroceryItem Check4;
	public GroceryItem Check5;

	//Make public when done testing
	GroceryItem XMas1;
	GroceryItem XMas2;
	GroceryItem Xmas3;


	// Use this for initialization
	void Start () {
		int seed = GameManager.Instance.getLevel ();
		weekDay (seed);

//		XMas1.setValues(50, 0, 0, 0);
//		XMas2.setValues(80, 0, 0, 0);
//		Xmas3.setValues(10, 0, 0, 0);
	}

	void weekDay(int day){
		switch (day) {
		case 1:	//Monday
			placeholder.texture = backDrops [0];
			Debug.Log ("its monday!");
			fillMonday ();
			break;
		case 2:	//Tuesday
			placeholder.texture = backDrops [1];
			fillTuesday ();
			break;
		case 3: //Wednesday
			placeholder.texture = backDrops [2];
			fillWednesday ();
			break;
		case 4: //Thursday
			placeholder.texture = backDrops [3];
			fillThursday ();
			break;
		case 5: //Friday
			placeholder.texture = backDrops [4];
			fillFriday ();
			break;
		}
	}

	//Values Stored Cost - Family - HP - Happiness
	void fillMonday(){
		Check1.setValues(5, 5, -5, 0);
		Check2.setValues(40, 20, 15, 15);
		Check3.setValues(7, 0, 5, 0);
		Check4.setValues(15, 0, 10, 0);
		Check5.setValues(20, 10, 0, 15);
		Debug.Log ("Values done setting.");
	}

	void fillTuesday(){
		Check1.setValues(7, 0, 5, 0);
		Check2.setValues(40, 20, 15, 15);
		Check3.setValues(10, 0, 5, 5);
		Check4.setValues(15, 5, -5, 10);
		Check5.setValues(25, 15, 0, 0); }

	void fillWednesday(){
		Check1.setValues(20, 0, -5, 15);
		Check2.setValues(45, 20, 15, 10);
		Check3.setValues(15, 0, 10, 0);
		Check4.setValues(10, 5, 5, 0);
		Check5.setValues(5, 2, 2, 2);	}

	void fillThursday(){
		Check1.setValues(7, 2, 5, 0);
		Check2.setValues(45, 15, 15, 10);
		Check3.setValues(15, 0, 0, 10);
		Check4.setValues(10, 2, 5, 0);
		Check5.setValues(25, 20, 10, 0);	}

	void fillFriday(){
		Check1.setValues(7, 5, 2, 0);
		Check2.setValues(40, 15, 15, 10);
		Check3.setValues(5, 5, 5, 5);
		Check4.setValues(10, 15, 0, 0);
		Check5.setValues(10, 5, 0, 10);	}
}
