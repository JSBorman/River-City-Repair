using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircuitOutput : MonoBehaviour {

    public string conditions;
    
    CircuitManager circuit;
    CircuitLight display;

    public bool state;

    void Awake() {

    }

    // Use this for initialization
    void Start () {
        display = GetComponent<CircuitLight>();
        circuit = GetComponentInParent<CircuitManager>();
        calculate();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool calculate() {
        List<string>tmpList = new List<string>(conditions.Split(' '));
        int i = 0;
        int infiniteProtector = 0;
        while (i < tmpList.Count && infiniteProtector<10000) {
            switch (tmpList[i]) {
                case "||":
                    tmpList[i-2]=(bool.Parse(tmpList[i-2]) || bool.Parse(tmpList[i-1])).ToString();
                    tmpList.RemoveAt(i);
                    tmpList.RemoveAt(i - 1);
                    i--;
                    break;
                case "&&":
                    tmpList[i - 2] = (bool.Parse(tmpList[i - 2]) && bool.Parse(tmpList[i - 1])).ToString();
                    tmpList.RemoveAt(i);
                    tmpList.RemoveAt(i - 1);
                    i--;
                    break;
                case "!":
                    tmpList[i - 1] = (!bool.Parse(tmpList[i - 1])).ToString();
                    tmpList.RemoveAt(i);
                    break;
                default:
                    if (!circuit.IsActive(int.Parse(tmpList[i]))) {
                        return false;
                    }
                    tmpList[i] = circuit.GetState(int.Parse(tmpList[i])).ToString();
                    i++;
                    break;
            }
            infiniteProtector++;
        }
        ChangeState(bool.Parse(tmpList[0]));
        return state;
    }

    void ChangeState(bool newState) {
        state = newState;
        display.SetLight(state);
    }
}
