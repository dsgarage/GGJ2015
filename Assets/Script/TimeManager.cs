using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    #region Members

    float _elapsedTime = 0.0f;
    public float ElapsedTime {
        get {
            return _elapsedTime;
        }
        private set {
            _elapsedTime = value;
        }
    }

    #endregion

    #region System Calls

    void Update () {
        _elapsedTime += Time.deltaTime;
    }

    #endregion
}
