using UnityEngine;
using System.Collections;

public class Checkout : MonoBehaviour {

	public StatObj hp;
	public StatObj happy;
	public StatObj fam;

	public GroceryManager grocer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickMe(){

		if (grocer.getCost() <= GameManager.Instance.getPlayerMun ()) {
			GameManager.Instance.updatePlayerFam (fam.getValue ());
			GameManager.Instance.updatePlayerHP (hp.getValue ());
			GameManager.Instance.updatePlayerHappy (happy.getValue ());
			GameManager.Instance.updatePlayerMun (grocer.getCost() * -1);

			//Trigger Next scene
			GameManager.Instance.nextLevel ();
		}
		//Else trigger subtitle
	}


}
