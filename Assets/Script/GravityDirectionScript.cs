using UnityEngine;
using System.Collections;

public class GravityDirectionScript : MonoBehaviour {

    /// <summary>
    /// 設定する重力ベクトル
    /// </summary>
    private Vector3 m_gravityDirection;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player")
        {
            m_gravityDirection = setDirection;
            Physics.gravity = m_gravityDirection;
        }
    }

    /// <summary>
    /// 重力ベクトル設定プロパティ
    /// </summary>
    public Vector3 setDirection { set; private get; }
}
