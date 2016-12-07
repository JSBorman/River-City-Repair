using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventManager : MonoBehaviour {

	/* Events need to store:
	 *  - Image with opening Text
	 *  - Number of choices
	 *  - Text for choices
	 *  - Stat changes for each choice
	 *  - Monetary cost of options
	 */

	public RawImage placeholder;
	public Texture[] backDrops = new Texture[7];
	public TriggerEvent ButtonA;
	public TriggerEvent OtherButton;

	//Text displayed on each option
	string A = "";
	string B = "";

	//Gains or Losses. Order: Money, Fam, HP, Happiness
	int[] choiceA, choiceB;

	//Monetary Cost of option A
	int costA = 0;

	//Special Event Triggers
	bool halfWages, halfWallet = false;

	// Use this for initialization
	void Start () {

		//On Friday don't get half Wage event
		if (GameManager.Instance.getLevel() == 5)
			GameManager.Instance.usedClues.Remove (5);

		int seed = (int) Random.Range ((float) 1, (float) GameManager.Instance.usedClues.Count);	//roll random index from usedClues
		seed = (int) GameManager.Instance.usedClues[seed];
		GameManager.Instance.usedClues.Remove(seed);		 //Remove item from used clues
		switchEvents(seed);
	}

	//Gains or Losses Order: Money, Fam, HP, Happiness
	//Large: 20, 25
	//Medium: 10, 15
	//Small: 5
	void switchEvents(int seed){
		switch (seed) {
		case 1:	//Large Cost, Large Rewards & Losses
			placeholder.texture = backDrops[0];

			A = "Pay for the surgery - $50";
			choiceA = new int[] { -50, 25, 0, 20};
			costA = 50;

			B = "Put the dog to sleep";
			choiceB= new int[]{ 0, -15, 0, -20};

			break;
		case 2:
			placeholder.texture = backDrops[1];
			A = "Send money to pay for the repairs";
			choiceA = new int[] { -20, 10, 0, 5};
			costA = 20;

			B = "Tell her to figure it out herself";
			choiceB= new int[]{ 0, -10, 0, -5};


			break;
		case 3:
			placeholder.texture = backDrops[2];
			A = "Accept the offer +$50";
			choiceA = new int[] {50, 0, -25, 0};

			B = "Close your laptop & re-evaluate your life";
			choiceB = new int[] { 0, 5, 5, 10};

			break;
		case 4:
			placeholder.texture = backDrops[3];
			A = "Give him the money: Lose half of wallet";
			choiceA = new int[] {0, 0, 0, 0};
			halfWallet = true;

			B = "Attempt to fight him off";
			choiceB = new int[] { 0, 0, -15, 0};

			break;
		case 5:
			placeholder.texture = backDrops[4];
			A = "Leave work early tomorrow for half wages";
			choiceA = new int[] {0, 20, 0, 20};
			bool halfWages = true;

			B = "Can't afford to miss work";
			choiceB = new int[] { 0, -10, 0, -10};

			break;
		case 6:
			placeholder.texture = backDrops[5];
			A = "That's a great idea!";
			choiceA = new int[] {20, -10, 0, 5};

			B = "No, you need to focus on your studies.";
			choiceB = new int[] { 0, 15, 0, 10};

			break;
		default:
			placeholder.texture = backDrops[6];
			A = "Keep it for expenses +$20";
			choiceA = new int[] {20, 5, 0, 5};

			B = "Put it straight into the college fund";
			choiceB = new int[] { 0, 10, 0, 20};
			break;
		}

		buttonLogicA (choiceA, halfWages, halfWallet);
		buttonLogicB (choiceB);
	}

	public void buttonLogicA(int[] aRes, bool wages, bool wallet){
		//Update button1
		ButtonA.setCost(costA);
		ButtonA.setMoney (aRes [0]);
		ButtonA.setFam (aRes [1]);
		ButtonA.setHP (aRes [2]);
		ButtonA.setHappy (aRes [3]);
		ButtonA.setOurText (A);

		ButtonA.setHalfWages (halfWages);
		ButtonA.setHalfWallet (halfWallet);

		//Reset bools
		halfWages = false;
		halfWallet = false;
	}

	public void buttonLogicB(int[] bRes){
		//Update button2
		OtherButton.setMoney (bRes [0]);
		OtherButton.setFam (bRes [1]);
		OtherButton.setHP (bRes [2]);
		OtherButton.setHappy (bRes [3]);
		OtherButton.setOurText (B);
	}

}
