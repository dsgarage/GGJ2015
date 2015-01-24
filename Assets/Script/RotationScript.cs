using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

    #region Public Methods

    /// <summary>
    /// 衝突した瞬間
    /// </summary>
    void OnCollisionEnter (Collision other) {
        Test();
    }

    /// <summary>
    /// 回転処理
    /// </summary>
    public void Rotation () {
        StartCoroutine(RotateAnimation ());
    }

    #endregion

    /// <summary>
    /// 回転用コルーチン
    /// </summary>
    IEnumerator RotateAnimation () {
        float time = 0.0f;

        float startRotation = transform.localEulerAngles.y;
        float prevRotation = transform.localEulerAngles.y;

        // 指定時間回す
        while (time < AnimationTime) {
            time += Time.deltaTime;

            // Easingを使用したすこしずつ回転
            Vector3 nowEuler = transform.localEulerAngles;
            nowEuler.y += Easing.Ease(
                Easing.EaseType.Out, 
                Easing.Type.Quadratic, 
                time, 
                startRotation, 
                AmountOfRotate, 
                AnimationTime) - prevRotation;
            transform.localEulerAngles = nowEuler;

            // 今回の回転量を保存
            prevRotation = transform.localEulerAngles.y;

            yield return null;
        }
    }

    #region Members

    [SerializeField]
    float _animationTime;
    public float AnimationTime {
        get {
            return _animationTime;
        }
        set {
            _animationTime = value;
        }
    }

    [SerializeField]
    float _amountOfRotate;
    public float AmountOfRotate {
        get {
            return _amountOfRotate;
        }
        set { 
            _amountOfRotate = value;
        }
    }

    #endregion

    void Test () {
        Rotation();
    }
}
