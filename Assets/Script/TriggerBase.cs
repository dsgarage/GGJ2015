using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerBase : MonoBehaviour
{
    EventScript _eventScript;
    public EventScript EventScript {
        protected get {
            return _eventScript;
        }
        set {
            _eventScript = value;
        }
    }
}
