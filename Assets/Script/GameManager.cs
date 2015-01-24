using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームマネージャ
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager> {

    #region Members

    GameObject _player;
    public GameObject Player {
        get {
            return _player;
        }
    }

    #endregion

    #region System Calls

    void Update () {

    }

    #endregion
}
