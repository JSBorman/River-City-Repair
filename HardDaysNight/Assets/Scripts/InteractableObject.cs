using UnityEngine;
using System.Collections;

public class InteractableObject : WorldObject {

    Renderer r;
    protected Material outline;
    float outlineWidth = .02f;

    // Use this for initialization
    void Start() {
        Init();
    }

    public override void Init() {
        base.Init();
        r = GetComponent<Renderer>();
        foreach (Material m in r.materials) {
            if (m.name.ToLower().Contains("outline")) {
                outline = m;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        doUpdate();
    }

    public override void doUpdate() {
        base.doUpdate();
    }

    public virtual void onGazeEnter() {
        outline.SetFloat("_Outline", outlineWidth);
    }

    public virtual void onGazeExit() {
        outline.SetFloat("_Outline", 0f);
    }

    public virtual void Interact() {
        throw new System.NotImplementedException();
    }
}
