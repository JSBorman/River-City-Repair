using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Game manager static instance, use this for persistent management
    public static GameManager Instance;
    public bool debug = false;

    public Player player;

    //Control Keys not in Axes
    public KeyCode INTERACT = KeyCode.E;

	// Use this for initialization
	void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
