using UnityEngine;
using System.Collections;

public class Pickup : InteractableObject {

	// Use this for initialization
	void Start () {
        Init();
    }

    public override void Init() {
        base.Init();
    }
	
	// Update is called once per frame
	void Update () {
        doUpdate();
	}

    public override void doUpdate() {
        base.doUpdate();
    }

    public override void Interact() {
        base.Interact();
        GameManager.Instance.player.Pickup(this);
    }
}
