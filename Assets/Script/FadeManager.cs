using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : SingletonMonoBehaviour<FadeManager> {

	#region Public Methods

	public void LoadLevel (string scene, float interval) {
		if (IsFading) {
			return;
		}

		StartCoroutine(TransScene(scene, interval));
	}

	#endregion

	#region Private Methods

	IEnumerator TransScene (string scene, float interval) {
		float time = 0.0f;
		{
			IsFading = true;

			while (time <= interval) {
				Color color = Image.color;
				color.a = Mathf.Lerp(0.0f, 1.0f, time / interval);
				Image.color = color;
				time += Time.deltaTime;
				yield return 0;
			}
		}

		Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 1.0f);

		Application.LoadLevel(scene);

		time = 0.0f;

		{
			while (time <= interval) {
				Color color = Image.color;
				color.a = Mathf.Lerp(1.0f, 0.0f, time / interval);
				Image.color = color;
				time += Time.deltaTime;
				yield return 0;
			}
		}

		Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0.0f);

		IsFading = false;
	}

	#endregion

	#region System Calls

	override protected void Awake () {
		base.Awake();
		DontDestroyOnLoad(this.gameObject);

		Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0.0f);

	}

	#endregion

	#region Members

	[SerializeField]
	Image _image;
	Image Image {
		get {
			if (_image == null) {
				Debug.LogError("Image is nothing");
				return null;
			}
			return _image;
		}
	}

	bool _isFading = false;
	bool IsFading {
		get {
			return _isFading;
		}
		set {
			_isFading = value;
		}
	}

	#endregion
}
