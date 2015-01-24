using UnityEngine;
using System.Collections;

public class OnTriggerEnterScript : TriggerBase {

    Collider _collider;
    public Collider Collider {
        get {
            return _collider;
        }
        private set {
            _collider = value;
        }
    }

    void OnTriggerEnter (Collider collider) {
        Collider = collider;
        EventScript.Run(this);
    }
}
