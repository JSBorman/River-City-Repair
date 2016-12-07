using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTrigger : MonoBehaviour {

    public string text;

    void OnTriggerEnter(Collider o) {
        GameManager.Instance.showSubtitle(text);
        Destroy(gameObject);
    }
}
