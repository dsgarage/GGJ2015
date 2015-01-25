using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayScript : MonoBehaviour {
    /// <summary>
    /// サウンド
    /// </summary>
    [SerializeField]
    private AudioClip sound;

    /// <summary>
    /// 触れた瞬間
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            sound = setSound;
            audio.PlayOneShot(sound);
        }
    }

    /// <summary>
    /// サウンド設定プロパティ
    /// </summary>
    public AudioClip setSound { set; private get; }
}
