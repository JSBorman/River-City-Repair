using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public float reachDistance = 5f;
    public WorldObject gazedObject;
    

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
        if (Input.GetAxis("Interact")==1) {
            if (gazedObject!=null && gazedObject is Pickup) {
                //TODO: Make pickups trigger flags in GameManager
                Debug.Log("Picked Up: " + gazedObject.gameObject.name);
                Destroy(gazedObject.gameObject);
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
        gazedObject = reachCast.collider.GetComponent<WorldObject>();
        if (gazedObject != null) {
            gazedObject.onGazeEnter();
        }
    }
}
