using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour {

	/* Events need to store:
	 *  - Image with opening Text
	 *  - Number of choices
	 *  - Text for choices
	 *  - Stat changes for each choice
	 *  - Monetary cost of options
	 */

	public Sprite placeholder;
	int[] usedClues = { 0, 0, 0, 0, 0, 0, 0 };	//Holds 1 if used

	public Object ButtonA, ButtonB, ButtonC;

	//Whether a third option is available (true if not)
	bool noThird = true;

	//Text displayed on each option
	string A, B, C = "";

	//Gains or Losses. Order: Money, Fam, HP, Happiness
	int[] choiceA, choiceB, choiceC;

	//Monetary Cost of option
	int costA, costB, costC = 0;

	// Use this for initialization
	void Start () {
		//Load Sprites
		Sprite placeholder1 = Resources.Load<Sprite> ("Random-Events/Random-Event1.png");
		Sprite placeholder2 = Resources.Load<Sprite> ("Random-Events/Random-Event2.png");
		Sprite placeholder3 = Resources.Load<Sprite> ("Random-Events/Random-Event3.png");
		Sprite placeholder4 = Resources.Load<Sprite> ("Random-Events/Random-Event4.png");
		Sprite placeholder5 = Resources.Load<Sprite> ("Random-Events/Random-Event5.png");
		Sprite placeholder6 = Resources.Load<Sprite> ("Random-Events/Random-Event6.png");
		Sprite placeholder7 = Resources.Load<Sprite> ("Random-Events/Random-Event7.png");

		//roll random number
		//Check if item was used & reroll if true
		switchEvents(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Gains or Losses Order: Money, Fam, HP, Happiness
	void switchEvents(int seed){
		switch (seed) {
		case 1:
			placeholder = placeholder1;

			A = "Pay for the surgery - $50";
			choiceA = new int[] { -50, 20, 0, 20};
			int costA = 50;

			B = "Put the dog to sleep";
			choiceB= new int[]{ 0, -20, 0, -25};
			
			noThird = true;
			break;
/*		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break; */
		default:
			play
			break;
		}

		buttonLogic (choiceA, choiceB, choiceC);
	}

	public void buttonLogic(int[] aRes, int[] bRes, int[] cRes){

		//Update button1
		//Update button2

		//Check to update button 3
		if (noThird) {
			//Delete button3
		} else {
			//Fillout button three
		}
	}

}
