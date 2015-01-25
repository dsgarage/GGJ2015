using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    private GameObject m_playerObject;
    /// <summary>
    /// オブジェクトの物理演算
    /// </summary>
    private Rigidbody m_rigitbody;
    /// <summary>
    /// 浮力
    /// </summary>
    [SerializeField]
    private Vector3 Float;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //Float = new Vector3(0, setFloatValue, 0);
            Physics.gravity = Physics.gravity + Float;
            Debug.Log(m_rigitbody.useGravity);
        }
    }

    /// <summary>
    /// 浮力設定プロパティ
    /// </summary>
    public float setFloatValue { set; private get; }
}
