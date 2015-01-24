using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームマネージャ
/// </summary>

public class GameManager : SingletonMonoBehaviour<GameManager> {

    #region Members

    public float m_time = 0;

    private GameObject m_player;
    private float m_score = 0;
    private int m_wait = 0;
    private int m_speed = 0;
    private int m_jump = 0;
    private int m_tafness = 0;
    


    public GameObject Player {
        get { return m_player; }
    }

    #endregion

    #region System Calls

    void Update () {
        m_score += Time.deltaTime;

    }

    #endregion
}
