using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatSwapping : MonoBehaviour {

	public Image full;
	public Sprite[] stages;
	public int type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (type == 0) {	//Family
			if (getStat () >= 100) {
				return;
			} else if (getStat () >= 70) {
				full.sprite = stages [1];
				return;
			} else if (getStat () >= 50) {
				full.sprite = stages [2];
				return;
			} else if (getStat () >= 30) {
				full.sprite = stages [3];
				return;
			} else {
				full.sprite = stages [4];
				return;
			}
		}
	}

	int getStat() {
		if (type == 0)
			return GameManager.Instance.getPlayerFam();
		if (type == 1)
			return GameManager.Instance.getPlayerHP();

		return GameManager.Instance.getPlayerHappy();
	}
}
