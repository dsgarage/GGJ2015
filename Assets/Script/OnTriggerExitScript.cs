using UnityEngine;
using System.Collections;

public class OnTriggerExitScript : TriggerBase {

    Collider _collider;
    public Collider Collider {
        get {
            return _collider;
        }
        private set {
            _collider = value;
        }
    }

    void OnTriggerExit (Collider collider) {
        Collider = collider;
        EventScript.Run(this);
    }
}
