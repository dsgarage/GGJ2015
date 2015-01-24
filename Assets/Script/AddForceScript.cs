using UnityEngine;
using System.Collections;

public class AddForceScript : MonoBehaviour {

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    private GameObject m_playerObject;
    /// <summary>
    /// オブジェクトの物理演算
    /// </summary>
    private Rigidbody m_rigitbody;
    /// <summary>
    /// 設定する力ベクトル
    /// </summary>
    private Vector3 m_forceDirection;
    /// <summary>
    /// 設定する力
    /// </summary>
    private float m_forcePower;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player")
        {
            m_forceDirection = setDirection;
            m_forcePower = setPower;
            m_playerObject = other.gameObject;
            m_rigitbody = m_playerObject.GetComponent<Rigidbody>();
            m_rigitbody.rigidbody.AddForce(m_forceDirection * m_forcePower, ForceMode.VelocityChange);
            Debug.Log("force");
        }
    }

    /// <summary>
    /// 力ベクトル設定プロパティ
    /// </summary>
    public Vector3 setDirection { set; private get; }
    /// <summary>
    /// 力設定プロパティ
    /// </summary>
    public float setPower { set; private get; }
}
