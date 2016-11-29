using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircuitManager : MonoBehaviour {

    List<CircuitInput> inputs;
    List<CircuitOutput> outputs;

	// Use this for initialization
	void Start () {
        inputs = new List<CircuitInput>();
        inputs.AddRange(GetComponentsInChildren<CircuitInput>());
        outputs = new List<CircuitOutput>();
        outputs.AddRange(GetComponentsInChildren<CircuitOutput>());
        inputs=SortInputs(inputs);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    List<CircuitInput> SortInputs(List<CircuitInput> l) {
        if (l.Count <= 0) {
            return l;
        }
        CircuitInput p = l[Random.Range(0, l.Count)];
        List<CircuitInput> lt = new List<CircuitInput>();
        List<CircuitInput> eq = new List<CircuitInput>();
        List<CircuitInput> gt = new List<CircuitInput>();
        foreach (CircuitInput ci in l) {
            if (ci.index < p.index) {
                lt.Add(ci);
            } else if (ci.index == p.index) {
                eq.Add(ci);
            } else {
                gt.Add(ci);
            }
        }
        lt = SortInputs(lt);
        lt.AddRange(eq);
        lt.AddRange(SortInputs(gt));
        return lt;
    }
}
