using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : InteractableObject {

    public override void Interact() {
        GameManager.Instance.TryLevelEnd();
    }
}
