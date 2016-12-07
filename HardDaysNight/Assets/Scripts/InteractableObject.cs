using UnityEngine;
using System.Collections;

public class InteractableObject : WorldObject {

    protected Renderer r;
    protected Material outline;
    public GameObject outlinedMesh;
    public float outlineWidth = .2f;

    // Use this for initialization
    void Start() {
        Init();
    }

    public override void Init() {
        base.Init();
        if (outlinedMesh) {
            r = outlinedMesh.GetComponent<Renderer>();
        } else {
            r = GetComponent<Renderer>();
        }
        if (r) {
            foreach (Material m in r.materials) {
                if (m.name.ToLower().Contains("outline")) {
                    outline = m;
                }
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
        if (outline) {
            outline.SetFloat("_Outline", outlineWidth);
        }
    }

    public virtual void onGazeExit() {
        if (outline) {
            outline.SetFloat("_Outline", 0f);
        }
    }

    public virtual void Interact() {
        throw new System.NotImplementedException();
    }
}
