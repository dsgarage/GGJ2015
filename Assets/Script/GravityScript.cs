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
    /// 重力を有効化するかどうか
    /// </summary>
    [SerializeField]
    private bool isUseGravity;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            m_playerObject = other.gameObject;
            m_rigitbody = m_playerObject.GetComponent<Rigidbody>();
            //m_rigitbody.useGravity = setUseGravity;
            m_rigitbody.useGravity = isUseGravity;
            Debug.Log(m_rigitbody.useGravity);
        }
    }

    /// <summary>
    /// 重力の有無設定プロパティ
    /// </summary>
    public bool setUseGravity { set; private get; }
}
