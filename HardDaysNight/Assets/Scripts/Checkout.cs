using UnityEngine;
using System.Collections;

public class Checkout : MonoBehaviour {

	public StatObj old_health;
	public StatObj old_sleep;
	public StatObj old_fam;

	public StatObj new_health;
	public StatObj new_sleep;
	public StatObj new_fam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickMe(){
		old_health.addValue(new_health.getValue());
		old_sleep.addValue (new_sleep.getValue ());
		old_fam.addValue (new_fam.getValue ());

		//Trigger Next scene
		GameManager.Instance.nextLevel();
	}
}
