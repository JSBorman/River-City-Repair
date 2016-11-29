using UnityEngine;
using System.Collections;

public class CircuitInput : InteractableObject {

    public int index;
    public Color trueColor;
    public Color falseColor;

    public bool state = false;

    CircuitManager p;

	// Use this for initialization
	void Start () {
        Init();
	}

    public override void Init() {
        base.Init();
        p = GetComponentInParent<CircuitManager>();
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
        state = !state;
        p.Refresh();
        onGazeEnter();
    }


}
