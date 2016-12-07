using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : InteractableObject {

    GameObject c;
    Animator anim;
    TvState state = TvState.Inactive;
    Collider col;
    AudioSource speaker;

    public GameObject screen;
    public AudioClip broadcast;

    public enum TvState {
        Inactive,
        Closed,
        Open
    }

    void Start() {
        Init();   
    }

    private void Update() {
        doUpdate();
    }

    public override void doUpdate() {
        base.doUpdate();
        if (Input.GetKeyDown(GameManager.Instance.INTERACT) && state !=TvState.Inactive) {
            if (state == TvState.Open) {
                anim.ResetTrigger("Open");
                anim.SetTrigger("Close");
                col.enabled = true;
                if (GetComponentInChildren<CircuitManager>().IsFixed()) {
                    screen.SetActive(true);
                    speaker.PlayOneShot(broadcast);
                }
            }
            c.SetActive(false);
            GameManager.Instance.player.gameObject.SetActive(true);
            }
    }

    public override void Init() {
        base.Init();
        speaker = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
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
        onGazeExit();
    }

    private void OnMouseDown() {
        if (TvState.Closed == state) {
            col.enabled = false;
            anim.ResetTrigger("Close");
            Debug.Log("OpenTV");
            state = TvState.Open;
            anim.SetTrigger("Open");
        } else if (state == TvState.Open) {
            anim.ResetTrigger("Open");
            Debug.Log("CloseTV");
            state = TvState.Closed;
            anim.SetTrigger("Close");
        }
    }
}
