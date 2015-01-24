using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
public class ColorScript : MonoBehaviour
{

    #region Members

    MeshRenderer _meshRenderer;

    MeshRenderer MeshRenderer {
        get { 
            if (_meshRenderer == null) {
                _meshRenderer = GetComponent<MeshRenderer> ();
            }
            return _meshRenderer;
        }
    }

    [SerializeField]
    Color _color;

    public Color Color {
        get { return _color; }
        set {
            _color = value;
            StartCoroutine(ChangeColorAnimation());
        }
    }

    [SerializeField]
    float _animationTime = 0.5f;
    public float AnimationTime {
        get { 
            return _animationTime;
        }
    }

    #endregion

    #region System Calls

    void Start () {
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 色を帰る
    /// </summary>
    public void ChangeColor ()
    {
        Color = _color;
    }

    #endregion

    /// <summary>
    /// アニメーション処理
    /// </summary>
    IEnumerator ChangeColorAnimation () {
        float time = 0.0f;

        Color start = MeshRenderer.material.color;

        // 指定時間回す
        while (time < AnimationTime) {
            time += Time.deltaTime;

            // 色を徐々に線形で変えていく処理
            Color now = MeshRenderer.material.color;
            now.r = Mathf.Lerp(start.r, Color.r, time / AnimationTime);
            now.g = Mathf.Lerp(start.g, Color.g, time / AnimationTime);
            now.b = Mathf.Lerp(start.b, Color.b, time / AnimationTime);
            now.a = Mathf.Lerp(start.a, Color.a, time / AnimationTime);
            MeshRenderer.material.color = now;

            yield return null;
        }
    }
}
