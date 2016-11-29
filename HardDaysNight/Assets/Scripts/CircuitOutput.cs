using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircuitOutput : MonoBehaviour {

    public string conditions;

    public Material trueMat;
    public Material falseMat;

    Renderer r;
    CircuitManager circuit;

    public bool state;

    void Awake() {
        r = GetComponent<Renderer>();
    }

    // Use this for initialization
    void Start () {
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
        if (state) {
            r.sharedMaterial = trueMat;
        } else {
            r.sharedMaterial = falseMat;
        }
    }
}
