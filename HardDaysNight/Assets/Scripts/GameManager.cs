using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Game manager static instance, use this for persistent management
    public static GameManager Instance;
    public bool debug = false;

    public int levels = 1;
    public int currentLevel = 0;

    public Player player;
    public List<CircuitManager> circuits;

    //Control Keys not in Axes
    public KeyCode INTERACT = KeyCode.E;

	//Player Stats
	public int playerFam, playerHP, playerHappy;

    // Use this for initialization
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Circuit")) {
            CircuitManager c = g.GetComponent<CircuitManager>();
            if (c) {
                circuits.Add(c);
            }
        }
    }

    // Update is called once per frame
    void Update() {
		//If stats below 0
		//Trigger Game Over [Missing Art Assets]
        //Cheat Codes
        if (debug && Input.GetKeyDown(KeyCode.N)) {
            nextLevel();
        }
    }

    public void StartGame() {
        currentLevel = 0;
		levels = 0;
        nextLevel();

		playerFam = 100;
		playerHP = 100;
		playerHappy = 100;
    }

	//Currentlevel keeps track of which circuit level
	//Levels keeps track of when to switch to groceries & events
    public void nextLevel() {

		//If at main menu or Random Event, go to next circuit
		if (levels == 0 || levels == 7){
			LoadLevel (++currentLevel);
			levels = currentLevel;
		}

		//If finished circuit, load groceries
		else if (levels <= 5) {
			levels = 6;
			LoadLevel (levels);
		}
		//If finished groceries, load random event
		else if (levels == 6) {
			levels = 7;
			LoadLevel (levels);
		}
    }

    void LoadLevel(int n) {
        SceneManager.LoadScene(n);
    }

    public void TryLevelEnd() {
        foreach (CircuitManager c in circuits) {
            if (!c.IsFixed()) {
                return;
            }
        }
        nextLevel();
    }

	//Returns the most recent circuit level
	public int getLevel(){
		return currentLevel;
	}

	//Returns specific player stat
	public int getPlayerFam(){ return playerFam;}
	public int getPlayerHP(){ return playerHP;	}
	public int getPlayerHappy(){ return playerHappy;}

	//Given int, adds / subtracts from current total
	public void updatePlayerFam(int fam){ playerFam += fam;}
	public void updatePlayerHP(int hp){ playerHP += hp;}
	public void updatePlayerHappy(int happy){ playerHappy += happy;}

}