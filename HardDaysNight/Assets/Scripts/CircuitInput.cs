using UnityEngine;
using System.Collections;

public class CircuitInput : InteractableObject {

    public int index;
    public Color trueColor;
    public Color falseColor;

    public bool state = false;

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        doUpdate();
	}

    public override void onGazeEnter() {
        base.onGazeEnter();
        if (state) {
            outline.SetColor("_OutlineColor",trueColor);
        } else {
            outline.SetColor("_OutlineColor",falseColor);
        }
    }

    public override void onGazeExit() {
        base.onGazeExit();
    }

    public override void Interact() {
        base.Interact();
        throw new System.NotImplementedException();
    }


}
