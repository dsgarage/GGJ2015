using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportScript : MonoBehaviour
{

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    private GameObject[] m_playerObjects;
    /// <summary>
    /// 世界においたテレポートオブジェクトの数
    /// </summary>
    private static int ObjectCount = 0;
    /// <summary>
    /// 全テレポートオブジェクト
    /// </summary>
    private static List<GameObject> AllObject = new List<GameObject>();
    /// <summary>
    /// 前回のったテレポートオブジェクト
    /// </summary>
    private static int oldObject = 0;
    /// <summary>
    /// プレイヤーとの距離
    /// </summary>
    private float toPlayerDistance;
    /// <summary>
    /// 最小距離
    /// </summary>
    private float minDis = 7;
    /// <summary>
    /// 近づき続けた時間
    /// </summary>
    private static float nearSecond = 0;
    /// <summary>
    /// 近づき続ける最大時間
    /// </summary>
    private static float nearMaxSecond = 2.0f;

    void Awake()
    {
        m_playerObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    // Use this for initialization
    void Start()
    {
        this.gameObject.name = "TeleportObject_" + ObjectCount;
        AllObject.Add(this.gameObject);
        ObjectCount++;
    }

    // Update is called once per frame
    void Update()
    {
        m_playerObjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < m_playerObjects.Length; i++)
        {
            toPlayerDistance = Vector3.Distance(this.transform.position, m_playerObjects[i].transform.position);
            //Debug.Log("toPlayerDistance = " + toPlayerDistance);
            //近づいたら
            if (toPlayerDistance <= minDis)
            {
                nearSecond += Time.deltaTime;
                if (nearSecond >= nearMaxSecond)
                {
                    //同じ場所にワープしないようにする
                    int rand = (int)Random.Range(0, AllObject.Count);
                    while (oldObject == rand)
                    {
                        rand = (int)Random.Range(0, AllObject.Count);
                    }
                    oldObject = rand;
                    GameObject tlp = GameObject.Find("TeleportObject_" + rand);
                    m_playerObjects[i].transform.position = tlp.transform.position + new Vector3(0, 2, 0);
                    nearSecond = 0;
                }
            }
        }
    }
}