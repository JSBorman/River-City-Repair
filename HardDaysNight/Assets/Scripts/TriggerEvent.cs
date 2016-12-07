using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* For use on selection of random event choice */
public class TriggerEvent : MonoBehaviour {

	public int fam;
	public int hp;
	public int happy;

	public void onClickMe(){
		GameManager.Instance.updatePlayerFam (fam);
		GameManager.Instance.updatePlayerHP (hp);
		GameManager.Instance.updatePlayerHappy (happy);

		//Trigger Next scene
		GameManager.Instance.nextLevel ();
	}
}
