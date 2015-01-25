using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiTextScript : MonoBehaviour {
    /// <summary>
    /// キャンバスオブジェクトがあるか検索
    /// </summary>
    private GameObject SearchCanvas;
    /// <summary>
    /// キャンバス
    /// </summary>
    private GameObject Canvas;
    /// <summary>
    /// テキスト
    /// </summary>
    private Text uiText;

    void Awake()
    {
        SearchCanvas = GameObject.Find("Canvas") ;
        //キャンバスが存在しなかったらインスタンスプレハブ生成
        if (SearchCanvas == null)
        {
            Canvas = Resources.Load("UI/Canvas") as GameObject;
            GameObject clone = (GameObject)Instantiate(Canvas, Vector3.zero, new Quaternion());
            clone.name = "Canvas";
            uiText = clone.transform.FindChild("Text").GetComponent<Text>();
            uiText.text = "";
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player")
        {
            uiText.text = setText;
            Debug.Log("text");
        }
    }

    /// <summary>
    /// 離れた瞬間
    /// </summary>
    void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "Player")
        {
            uiText.text = "";
            //Debug.Log(m_rigitbody.useGravity);
        }
    }

    /// <summary>
    /// テキスト設定プロパティ
    /// </summary>
    public string setText { set; private get; }
}
