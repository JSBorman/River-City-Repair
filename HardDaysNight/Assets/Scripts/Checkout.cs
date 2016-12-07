using UnityEngine;
using System.Collections;

public class Checkout : MonoBehaviour {

	public StatObj hp;
	public StatObj happy;
	public StatObj fam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickMe(){
		GameManager.Instance.updatePlayerFam (fam.getValue ());
		GameManager.Instance.updatePlayerHP (hp.getValue ());
		GameManager.Instance.updatePlayerHappy (happy.getValue ());

		//Trigger Next scene
		GameManager.Instance.nextLevel();
	}
}
