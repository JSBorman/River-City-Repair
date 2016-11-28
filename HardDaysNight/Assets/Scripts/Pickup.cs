using UnityEngine;
using System.Collections;

public class Pickup : WorldObject {

    Renderer r;
    float outlineWidth=.02f;

	// Use this for initialization
	void Start () {
        Init();
    }

    public override void Init() {
        base.Init();
        r = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        doUpdate();
	}

    public override void doUpdate() {
        base.doUpdate();
    }

    public override void onGazeEnter() {
        base.onGazeEnter();
        foreach (Material m in r.materials) {
            if (m.name.ToLower().Contains("outline")) {
                m.SetFloat("_Outline", outlineWidth);
            }
        }
    }

    public override void onGazeExit() {
        base.onGazeExit();
        foreach (Material m in r.materials) {
            if (m.name.ToLower().Contains("outline")) {
                m.SetFloat("_Outline", 0f);
            }
        }
    }
}
