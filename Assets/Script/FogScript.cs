using UnityEngine;
using System.Collections;

public class FogScript : MonoBehaviour {

    /// <summary>
    /// フォグを使用するか?
    /// </summary>
    [SerializeField]
    bool _isFog;
    public bool IsFog {
        get {
            return _isFog;
        }
        set {
            RenderSettings.fog = value;
            _isFog = value;
        }
    }

    /// <summary>
    /// フォグのモードの切り替え
    /// </summary>
    [SerializeField]
    FogMode _fogMode;
    public FogMode FogMode {
        get {
            return _fogMode;
        }
        set {
            RenderSettings.fogMode = value;
            _fogMode = value;
        }
    }

    /// <summary>
    /// フォグの色
    /// </summary>
    [SerializeField]
    Color _color;
    public Color Color {
        get {
            return _color;
        }
        set {
            RenderSettings.fogColor = value;
            _color = value;
        }
    }

    /// <summary>
    /// フォグの濃さ
    /// </summary>
    [SerializeField]
    float _density;
    public float Density {
        get {
            return _density;
        }
        set {
            RenderSettings.fogDensity = value;
            _density = value;
        }
    }

    /// <summary>
    /// フォグが始まる位置
    /// </summary>
    [SerializeField]
    float _startDistance;
    public float StartDistance {
        get {
            return _startDistance;
        }
        set {
            RenderSettings.fogStartDistance = value;
            _startDistance = value;
        }
    }

    /// <summary>
    /// 見えなくなる位置
    /// </summary>
    [SerializeField]
    float _endDistance;
    public float EndDistance {
        get {
            return _endDistance;
        }
        set {
            RenderSettings.fogEndDistance = value;
            _endDistance = value;
        }
    }

    /// <summary>
    /// フォグのパラメータの更新
    /// </summary>
    void Fog () {
        IsFog = _isFog;
        FogMode = _fogMode;
        Color = _color;
        Density = _density;
        StartDistance = _startDistance;
        EndDistance = _endDistance;
    }
}
