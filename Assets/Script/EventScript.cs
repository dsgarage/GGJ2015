using UnityEngine;
using System;
using System.Collections;

public class EventScript : MonoBehaviour {

    string _className;

    public string ClassName {
        get {
            return _className;
        }
        set {
            // 前のやつはいらなくなったので破棄
            if (_className != null) {
                TriggerBase trigger = GetComponent <TriggerBase> ();
                Destroy (trigger);
            }

            _className = value;

            // 新しくコンポーネントを追加
            TriggerBase triggerBase = this.gameObject.AddComponent (_className) as TriggerBase;
            triggerBase.EventScript = this;

            if (triggerBase == null) {
                Debug.Log ("残念");
            }
        }
    }

    public delegate void RunDelegate (TriggerBase component);

    RunDelegate _run;

    public RunDelegate Run {
        get {
            return _run;
        }
        set {
            _run = value;
        }
    }

    Func<bool> _trigger;

    public Func<bool> Trigger {
        get {
            return _trigger;
        }
        private set {
            _trigger = value;
        }
    }

    void SetOtherTrigger (Func<bool> trigger)
    {
        Trigger = trigger;
    }

    void Update ()
    {
        if (Trigger != null) {
            if (Trigger ()) {
                Run (null);
            }
        }
    }
}
