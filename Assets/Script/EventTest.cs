using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : EventScript {
    void Awake () {
        this.ClassName = "OnCollisionEnterScript";
        this.Run = (TriggerBase trigger) =>
        {
            Debug.Log ("衝突しました。");
        };
    }
}
