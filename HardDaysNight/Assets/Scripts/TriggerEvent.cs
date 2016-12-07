using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* For use on selection of random event choice */
public class TriggerEvent : MonoBehaviour {

	public Text text;

	int fam = 0;
	int hp = 0;
	int happy = 0;
	int money = 0;
	int cost = 0;

	bool halfWages = false;
	bool halfWallet = false;

	void Start(){
	}

	public void onClickMe(){

		//Ensure player can afford monetary values of choice
		if (GameManager.Instance.getPlayerMun () >= cost) {

			if (halfWages)
				GameManager.Instance.setHalfWages (true);

			if (halfWallet) {
				int tmp = GameManager.Instance.getPlayerMun () / 2;
				GameManager.Instance.updatePlayerMun (-tmp);	//Half wallet from mugging
			} else { 			
				GameManager.Instance.updatePlayerMun (money);	//Also covers cost
			}

			GameManager.Instance.updatePlayerFam (fam);
			GameManager.Instance.updatePlayerHP (hp);
			GameManager.Instance.updatePlayerHappy (happy);

			//Trigger Next scene
			GameManager.Instance.nextLevel ();
		}
	}

	//Helper Functions
	public void setFam(int f){fam = f;}
	public void setMoney(int f){money = f;}
	public void setHP(int f){hp = f;}
	public void setHappy(int f){happy = f;}
	public void setCost(int f){cost = f;}

	//For Special Events
	public void setHalfWages(bool half){ halfWages = half;}
	public void setHalfWallet(bool half){halfWallet = half;}

	public void setOurText(string option){
		text.text = option;
		return;
	}
}
