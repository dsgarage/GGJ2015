using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
    /// <summary>
    /// 移動する対象のオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_object;

    /// <summary>
    /// 移動用のコルーチン
    /// </summary>
    IEnumerator MoveObject () {
        float time = 0.0f;

        Vector3 startPosition = m_object.transform.localPosition;
        Vector3 endPosition = startPosition + AmountOfMove;

        // 指定時間回す
        while (time < AnimationTime)
        {
            time += Time.deltaTime;

            m_object.transform.localPosition = new Vector3(
                Easing.Ease (EaseType, Type, time, startPosition.x, AmountOfMove.x, AnimationTime),
                Easing.Ease (EaseType, Type, time, startPosition.y, AmountOfMove.y, AnimationTime),
                Easing.Ease (EaseType, Type, time, startPosition.z, AmountOfMove.z, AnimationTime)
            );

            yield return null;
        }

        // 最終位置に正確な値を代入して終了
        m_object.transform.localPosition = endPosition;
    }

    /// <summary>
    /// 指定位置まで移動します
    /// </summary>
    public void Move () {
        StartCoroutine(MoveObject ());
    }

    void Awake () {

        // パラメータを初期化
        EaseType = Easing.EaseType.Out;
        Type = Easing.Type.Cubic;
        AmountOfMove = new Vector3(3, 3, 0);
        AnimationTime = 1.0f;

        Move();
    }

    public Easing.EaseType EaseType { set; private get; }

    public Easing.Type Type { set; private get; }

    public Vector3 AmountOfMove { set; private get; }

    public float AnimationTime { set; private get; }
}
