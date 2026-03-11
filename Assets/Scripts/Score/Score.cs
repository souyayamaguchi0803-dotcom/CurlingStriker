using UnityEngine;
using UnityEngine.Assertions;

public readonly struct Score
{
	public readonly float Value;
	public const string unit = "m";
	public const float maxValue = 999f;

	// スコア値を直接受け取って初期化
	public Score(float rawValue)
	{
		Assert.IsTrue(rawValue >= 0f, $"スコアに負の値({rawValue})が指定されました");
		Value = Mathf.Clamp(rawValue, 0f, maxValue);
	}

	// スコアの表示
	public string Show()
	{
		return $"{Value:F2}{unit}";
	}

	// より良いスコアならtrueを返す
	public bool IsBetterThan(Score other)
	{
		return Value < other.Value;
	}
}
