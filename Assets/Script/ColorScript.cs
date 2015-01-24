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
            MeshRenderer.material.color = Color;
        }
    }

    #endregion

    /// <summary>
    /// 色を帰る
    /// </summary>
    public void ChangeColor ()
    {
        Color = _color;
    }
}
