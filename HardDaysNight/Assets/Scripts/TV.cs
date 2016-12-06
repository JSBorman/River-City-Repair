using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : InteractableObject {

    GameObject c;
    Animator anim;
    TvState state = TvState.Inactive;

    public enum TvState {
        Inactive,
        Closed,
        Open
    }

    void Start() {
        Init();   
    }

    public override void Init() {
        base.Init();
        c = transform.FindChild("ViewCamera").gameObject;
        c.SetActive(false);
        anim = GetComponent<Animator>();
    }

    public override void Interact() {
        c.SetActive(true);
        state = TvState.Closed;
        GameManager.Instance.player.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnMouseDown() {
        if (TvState.Closed == state) {
            Debug.Log("OpenTV");
            state = TvState.Open;
            anim.SetTrigger("Open");
        } else if (state == TvState.Open) {
            Debug.Log("CloseTV");
            state = TvState.Closed;
            anim.SetTrigger("Close");
        }
    }
}
