using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitLight : MonoBehaviour {

    public Sprite off;
    public Sprite True;
    public Sprite False;

    SpriteRenderer r;

    private void Start() {
        r = GetComponent<SpriteRenderer>();
        r.sprite = off;
    }

    private void OnMouseDown() {
        Debug.Log("Click");
    }

    public void SetLight(bool state) {
        if (state) {
            r.sprite = True;
        } else {
            r.sprite = False;
        }
    }

}
