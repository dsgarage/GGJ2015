using UnityEngine;
using System.Collections;

public class OnCollisionStayScript : TriggerBase {

    Collision _collision;
    public Collision Collision {
        get {
            return _collision;
        }
        private set {
            _collision = value;
        }
    }

    void OnCollisionStay (Collision collision) {
        Collision = collision;
        EventScript.Run (this);
    }
}
