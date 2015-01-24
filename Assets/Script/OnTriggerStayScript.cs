using UnityEngine;
using System.Collections;

public class OnTriggerStayScript : TriggerBase {

    Collider _collider;
    public Collider Collider {
        get {
            return _collider;
        }
        private set {
            _collider = value;
        }
    }

    void OnTriggerStay (Collider collider) {
        Collider = collider;
        EventScript.Run(this);
    }
}
