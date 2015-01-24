using UnityEngine;
using System.Collections;

public class TimeScaleScript : MonoBehaviour {

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    private GameObject m_playerObject;
    /// <summary>
    /// 設定するタイムスケール値
    /// </summary>
    private float m_timescale;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player")
        {
            m_timescale = setTimeScale;
            Time.timeScale = m_timescale;
        }
    }

    /// <summary>
    /// タイムスケール設定プロパティ
    /// </summary>
    public float setTimeScale { set; private get; }
}
