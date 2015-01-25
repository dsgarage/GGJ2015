using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LazerScript : MonoBehaviour {
    /// <summary>
    /// オブジェクトのマテリアル
    /// </summary>
    private Material[] m_mats;
    /// <summary>
    /// プロジェクトから読み込むマテリアル
    /// </summary>
    [SerializeField]
    private Material[] mat;
    /// <summary>
    /// ラインレンダラ
    /// </summary>
    private LineRenderer lineRenderer;
    /// <summary>
    /// レイキャスト
    /// </summary>
    private RaycastHit hit;
    /// <summary>
    /// 照射方向ベクトル
    /// </summary>
    private Vector3 vec;

    void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

	// Use this for initialization
	void Start () 
    {
        m_mats = mat;//renderer.materials;
        lineRenderer.enabled = true;
        lineRenderer.SetVertexCount(2);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //renderer.materials = m_mats;
        vec = this.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(this.transform.position, vec, out hit, Mathf.Infinity))
        {
            lineRenderer.material = m_mats[0];
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, hit.point + vec);   //不自然さ回避のためマテリアルを意図的に少し埋める
            //Debug.Log("hit");
        }
	}

    /// <summary>
    /// レーザーベクトル設定プロパティ
    /// </summary>
    public Vector3 setDirection { set; private get; }
}
