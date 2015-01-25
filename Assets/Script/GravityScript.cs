using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    private GameObject m_playerObject;
    /// <summary>
    /// オブジェクトの物理演算
    /// </summary>
    private Rigidbody m_rigitbody;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("========== Get Collision!! ==========");
        if (other.collider.tag == "Player")
        {
            Debug.Log("========== Get PlayerTag!! ==========");
            m_playerObject = other.gameObject;
            m_rigitbody = m_playerObject.GetComponent<Rigidbody>();
            m_rigitbody.useGravity = false;
            //Debug.Log(m_rigitbody.useGravity);
        }
    }

    /// <summary>
    /// 重力の有無設定プロパティ
    /// </summary>
    public bool setUseGravity { set; private get; }
}
