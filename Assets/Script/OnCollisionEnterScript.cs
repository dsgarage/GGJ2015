using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class OnCollisionEnterScript : TriggerBase {

    Collision _collision;
    public Collision Collision {
        get {
            return _collision;
        }
        private set {
            _collision = value;
        }
    }

    void OnCollisionEnter (Collision collision) {
        Collision = collision;
        EventScript.Run(this);
    }
}
