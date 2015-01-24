using UnityEngine;
using System.Collections;

public partial class Easing
{
	public enum Type
	{
		Linear = 0,
		Quadratic,
		Cubic,
		Quartic,
		Sinusoidal,
		Exponential,
		Circular,
	}

	public enum EaseType
	{
		In = 0,
		Out,
		InOut,
	}

	[System.Serializable]
	public class EaseEndParam
	{
		public Easing.EaseType easeType;
		public Easing.Type type;
		public float b;
		public float e;
		public float d;
	}

	[System.Serializable]
	public class EaseParam
	{
		public Easing.EaseType easeType;
		public Easing.Type type;
		public float b;
		public float c;
		public float d;
	}

	/// <summary>
	/// イージング
	/// </summary>
	/// <param name="ease">イージングのかかるところを設定</param>
	/// <param name="type">イージングの種類</param>
	/// <param name="t">時間(進行度)</param>
	/// <param name="b">開始の値(開始時の座標やスケールなど)</param>
	/// <param name="c">開始と終了の値の差分</param>
	/// <param name="d">Tween(トゥイーン)の合計時間</param>
	public static float Ease (EaseType ease, Type type, float t, float b, float c, float d)
	{
		return methodArray [(int)type, (int)ease] (t, b, c, d);
	}

	/// <summary>
	/// イージング
	/// </summary>
	/// <param name="param">パラメータ</param>
	/// <param name="t">時間(進行度)</param>
	public static float Ease (EaseParam param, float t)
	{
		return methodArray [(int)param.type, (int)param.easeType] (t, param.b, param.c, param.d);
	}

	/// <summary>
	/// イージング
	/// </summary>
	/// <param name="ease">イージングのかかるところを設定</param>
	/// <param name="type">イージングの種類</param>
	/// <param name="t">時間(進行度)</param>
	/// <param name="b">開始の値(開始時の座標やスケールなど)</param>
	/// <param name="e">終了の値</param>
	/// <param name="d">Tween(トゥイーン)の合計時間</param>
	public static float EaseEnd (EaseType ease, Type type, float t, float b, float e, float d)
	{
		return methodArray [(int)type, (int)ease] (t, b, e - b, d);
	}

	/// <summary>
	/// イージング
	/// </summary>
	/// <param name="param">パラメータ</param>
	/// <param name="t">時間(進行度)</param>
	public static float EaseEnd (EaseEndParam param, float t)
	{
		return methodArray [(int)param.type, (int)param.easeType] (t, param.b, param.e - param.b, param.d);
	}

	static float easeLinear (float t, float b, float c, float d)
	{
		t /= d;
		return c * t + b;
	}

	static float easeInQuadratic (float t, float b, float c, float d)
	{
		t /= d;
		return c * t * t + b;
	}

	static float easeOutQuadratic (float t, float b, float c, float d)
	{
		t /= d;
		return -c * t * (t - 2.0f) + b;
	}

	static float easeInOutQuadratic (float t, float b, float c, float d)
	{
		t /= d / 2.0f;
		if (t < 1.0f) {
			return c / 2.0f * t * t + b;
		}

		t--;
		return -c / 2.0f * (t * (t - 2.0f) - 1.0f) + b;
	}

	static float easeInCubic (float t, float b, float c, float d)
	{
		t /= d;
		return c * t * t * t + b;
	}

	static float easeOutCubic (float t, float b, float c, float d)
	{
		t /= d;
		t--;
		return c * (t * t * t + 1.0f) + b;
	}

	static float easeInOutCubic (float t, float b, float c, float d)
	{
		t /= d / 2.0f;
		if (t < 1.0f) {
			return c / 2.0f * t * t * t + b;
		}
		t -= 2.0f;
		return c / 2.0f * (t * t * t + 2.0f) + b;
	}

	static float easeInQuartic (float t, float b, float c, float d)
	{
		t /= d;
		return c * t * t * t * t + b;
	}

	static float easeOutQuartic (float t, float b, float c, float d)
	{
		t /= d;
		t--;
		return -c * (t * t * t * t - 1.0f) + b;
	}

	static float easeInOutQuartic (float t, float b, float c, float d)
	{
		t /= d / 2.0f;
		if (t < 1.0f) {
			return c / 2.0f * t * t * t * t + b;
		}
		t -= 2.0f;
		return -c / 2.0f * (t * t * t * t - 2.0f) + b;
	}

	static float easeInQuintic (float t, float b, float c, float d)
	{
		t /= d;
		return c * t * t * t * t * t + b;
	}

	static float easeOutQuintic (float t, float b, float c, float d)
	{
		t /= d;
		t--;
		return c * (t * t * t * t * t + 1.0f) + b;
	}

	static float easeInOutQuintic (float t, float b, float c, float d)
	{
		t /= d / 2.0f;
		if (t < 1.0f) {
			return c / 2.0f * t * t * t * t * t + b;
		}
		t -= 2.0f;
		return c / 2.0f * (t * t * t * t + 2.0f) + b;
	}

	static float easeInSinusoidal (float t, float b, float c, float d)
	{
		return -c * Mathf.Cos (t / d * (Mathf.PI / 2.0f)) + c + b;
	}

	static float easeOutSinusoidal (float t, float b, float c, float d)
	{
		return c * Mathf.Sin (t / d * (Mathf.PI / 2.0f)) + b;
	}

	static float easeInOutSinusoidal (float t, float b, float c, float d)
	{
		return -c / 2.0f * (Mathf.Cos (Mathf.PI * t / d) - 1.0f) + b;
	}

	static float easeInExponential (float t, float b, float c, float d)
	{
		return c * Mathf.Pow (2.0f, 10.0f * (t / d - 1.0f)) + b;
	}

	static float easeOutExponential (float t, float b, float c, float d)
	{
		return c * (-Mathf.Pow (2.0f, -10.0f * t / d) + 1.0f) + b;
	}

	static float easeInOutExponential (float t, float b, float c, float d)
	{
		t /= d / 2.0f;
		if (t < 1.0f) {
			return c / 2 * Mathf.Pow (2.0f, 10.0f * (t - 1.0f)) + b;
		}
		t--;
		return c / 2.0f * (-Mathf.Pow (2.0f, -10.0f * t) + 2.0f) + b;
	}

	static float easeInCircular (float t, float b, float c, float d)
	{
		t /= d;
		return -c * (Mathf.Sqrt (1.0f - t * t) - 1.0f) + b;
	}

	static float easeOutCircular (float t, float b, float c, float d)
	{
		t /= d;
		t--;
		return c * Mathf.Sqrt (1.0f - t * t) + b;
	}

	static float easeInOutCircular (float t, float b, float c, float d)
	{
		t /= d / 2.0f;
		if (t < 1.0f) {
			return -c / 2.0f * (Mathf.Sqrt (1.0f - t * t) - 1.0f); 
		}
		t -= 2.0f;
		return c / 2.0f * (Mathf.Sqrt (1.0f - t * t) + 1.0f) + b;
	}

	delegate float EaseMethod (float t,float b,float c,float d);

	static EaseMethod[,] methodArray = {
		{ easeLinear, easeLinear, easeLinear },
		{ easeInQuadratic, easeOutQuadratic, easeInOutQuadratic },
		{ easeInCubic, easeOutCubic, easeInOutCubic },
		{ easeInQuartic, easeOutQuartic, easeInOutQuartic },
		{ easeInQuintic, easeOutQuintic, easeInOutQuintic },
		{ easeInSinusoidal, easeOutSinusoidal, easeInOutSinusoidal },
		{ easeInCircular, easeOutCircular, easeInOutCircular },
	};
}

