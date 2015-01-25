using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

    [SerializeField]
    string sceneName;

    /// <summary>
    /// シーンの変更
    /// </summary>
    public void Change () {
        FadeManager.Instance.LoadLevel (sceneName, 0.5f);
    }
}
