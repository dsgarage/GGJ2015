using UnityEngine;
using System.Collections;

public class Singleton<T> where T : class, new() {
	public static T Instance {
		get {
			if (_instance == null) {
				_instance = new T();
			}
			return _instance;
		}
	}

	static T _instance;
}