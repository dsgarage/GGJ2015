using UnityEngine;
using System.Collections;

public class FreezeScript : MonoBehaviour {

    /// <summary>
    /// フリーズ状態か?
    /// </summary>
    bool IsFreeze { get; set; }

    /// <summary>
    /// フリーズ時の位置
    /// </summary>
    Vector3 FreezePosition { get; set; }

    /// <summary>
    /// フリーズ処理
    /// </summary>
    public void Freeze () {
        IsFreeze = true;
        FreezePosition = transform.localPosition;
    }

    /// <summary>
    /// フリーズ終了
    /// </summary>
    public void Melt () {
        IsFreeze = false;
    }

    void LateUpdate () {
        if (IsFreeze) {
            transform.localPosition = FreezePosition;
        }
    }

}
