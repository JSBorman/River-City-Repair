using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public float reachDistance = 5f;
    public InteractableObject gazedObject;
    

    Camera view;
    RaycastHit reachCast;

    void Awake() {

    }

    // Use this for initialization
    void Start () {
        view = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        calcView();
        if (Input.GetKeyDown(GameManager.Instance.INTERACT)) {
            if (gazedObject!=null) {
                gazedObject.Interact();
            }
        }
	}

    void calcView() {
        Physics.Raycast(view.transform.position, view.transform.forward, out reachCast, reachDistance);
        if (GameManager.Instance.debug) {
            Debug.DrawLine(view.transform.position, view.transform.position + view.transform.forward * reachDistance, Color.green);
        }
        if (reachCast.collider == null) {
            if (gazedObject != null) {
                gazedObject.onGazeExit();
                gazedObject = null;
            }
            return;
        }
        if (gazedObject != null) {
            if (reachCast.collider.gameObject == gazedObject.gameObject) {
                return;
            }
            gazedObject.onGazeExit();
        }
        gazedObject = reachCast.collider.GetComponent<InteractableObject>();
        if (gazedObject) {
            gazedObject.onGazeEnter();
        }
    }

    public void Pickup(Pickup p) {
        //TODO: Make pickups trigger flags in GameManager
        Debug.Log("Picked Up: " + p.gameObject.name);
        Destroy(p.gameObject);
    }
}
