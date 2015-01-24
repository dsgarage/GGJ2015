using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
	virtual protected void Awake () {
		if (Instance != this) {
			Destroy(this.gameObject);
		}
	}

	public static T Instance {
		get {
			if (_instance == null) {
				_instance = (T)FindObjectOfType(typeof(T));

				if (_instance == null) {
					Debug.LogError(typeof(T) + "is nothing");
					return null;
				}
			}
			return _instance;
		}
	}
	static T _instance;
}