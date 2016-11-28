using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {

    void Awake() {

    }

    // Use this for initialization
    void Start() {
        Init();

    }

    public virtual void Init() {

    }

    // Update is called once per frame
    void Update() {
        doUpdate();
    }

    public virtual void doUpdate() {

    }

    public virtual void onGazeEnter() {}

    public virtual void onGazeExit() {}
}
