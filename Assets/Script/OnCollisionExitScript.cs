using UnityEngine;
using System.Collections;

public class OnCollisionExitScript : TriggerBase {

    Collision _collision;
    public Collision Collision {
        get {
            return _collision;
        }
        private set {
            _collision = value;
        }
    }

    void OnCollisionExit (Collision collision) {
        Collision = _collision;
        EventScript.Run(this);
    }
}
