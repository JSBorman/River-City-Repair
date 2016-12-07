using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Game manager static instance, use this for persistent management
    public static GameManager Instance;
    public bool debug = false;

    public int levels = 1;
    public int currentLevel = 0;

	public ArrayList usedClues = new ArrayList {1, 2, 3, 4, 5, 6, 7};		

    public Player player;
    public List<CircuitManager> circuits;
    public Text subtitle;

    //Control Keys not in Axes
    public KeyCode INTERACT = KeyCode.E;

	//Player Stats
	public int playerFam, playerHP, playerHappy, playerMun;
	public bool gift1, gift2, gift3;
	bool halfWages = false;

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
        Debug.Log("Start");
        circuits.Clear();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Circuit")) {
            CircuitManager c = g.GetComponent<CircuitManager>();
            if (c) {
                Debug.Log("Got Circuit");
                circuits.Add(c);
            }
        }
        subtitle = GameObject.FindGameObjectWithTag("Subtitle").GetComponent<Text>(); ;
        findPlayer();
    }

    // Update is called once per frame
    void Update() {
		//If stats below 0
		//Trigger Game Over [Missing Art Assets]
        //Cheat Codes
        if (debug && Input.GetKeyDown(KeyCode.N)) {
			earnWages ();
			nextLevel();
        } else if (debug && Input.GetKeyDown(KeyCode.C)) {
            showSubtitle("Hllo");
        }
    }

    public void showSubtitle(string text, float seconds=5f) {
        subtitle.text = text;
        StopAllCoroutines();
        StartCoroutine(HideSubtitleAfter(seconds));
    }

    IEnumerator HideSubtitleAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        subtitle.text = "";
    }

    public void StartGame() {
        currentLevel = 0;
		levels = 0;
        nextLevel();

		playerFam = 100;
		playerHP = 100;
		playerHappy = 100;
		playerMun = 0;
		gift1 = false;
		gift2 = false;
		gift3 = false;
    }

	//Currentlevel keeps track of which circuit level
	//Levels keeps track of when to switch to groceries & events
    public void nextLevel() {

		//Win Game when done
		if (levels == 6 && currentLevel == 5) {
			LoadLevel (8);
		}

		//Lose game if lost stats
		else if ((getPlayerHP () <= 0 || getPlayerFam () <= 0 || getPlayerHappy () <= 0 ) && currentLevel > 2) {
			LoadLevel (9);
		}

		//If at main menu or Random Event, go to next circuit
		else if (levels == 0 || levels == 7){
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
        StartCoroutine(DelayLoad());
    }

    IEnumerator DelayLoad() {
        yield return new WaitForSeconds(.5f);
        Start();
    }

    private void findPlayer() {
        GameObject g = GameObject.Find("FPSController");
        if (g) {
            player = g.GetComponent<Player>();
        }
    }

    public void TryLevelEnd() {
        foreach (CircuitManager c in circuits) {
            if (!c.IsFixed()) {
                return;
            }
        }
		earnWages ();
        nextLevel();
    }

	public void earnWages(){
		Debug.Log ("Earning Wages");
		int tmpWages = 80;

		if (!halfWages)
			playerMun = playerMun + tmpWages;
		else if (halfWages) {
			playerMun = playerMun + (tmpWages / 2);
			halfWages = false;
		}
		Debug.Log ("Current Earnings: " + playerMun);
	}

	//Returns the most recent circuit level
	public int getLevel(){
		return currentLevel;
	}

	//Returns specific player stat
	public int getPlayerFam(){ return playerFam;}
	public int getPlayerHP(){ return playerHP;	}
	public int getPlayerHappy(){ return playerHappy;}
	public int getPlayerMun(){return playerMun;	}

	//Given int, adds / subtracts from current total
	public void updatePlayerFam(int fam){ playerFam += fam;}
	public void updatePlayerHP(int hp){ playerHP += hp;}
	public void updatePlayerHappy(int happy){ playerHappy += happy;}
	public void updatePlayerMun(int mun){playerMun += mun;}

	//For random event
	public void setHalfWages(bool rand){
		halfWages = rand;
		return;
	}

	public void setGift1(bool gift){
		gift1 = gift;
	}
	public void setGift2(bool gift){
		gift2 = gift;
	}
	public void setGift3(bool gift){
		gift3 = gift;
	}

}