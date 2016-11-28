using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Game manager static instance, use this for persistent management
    public static GameManager Instance;

	// Use this for initialization
	void Start () {
        if (GameManager.Instance = null)
        {
            GameManager.Instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
