using UnityEngine;
using System.Collections;

public class CircuitInput : MonoBehaviour {

    public int index;

    public bool state = false;
    public bool active = false;

    CircuitManager p;
    CircuitLight display;

	// Use this for initialization
	void Start () {
        p = GetComponentInParent<CircuitManager>();
        display = GetComponent<CircuitLight>();
    }

    public void OnMouseDown() {
        active = true;
        state = !state;
        display.SetLight(state);
        p.Refresh();

    }


}
