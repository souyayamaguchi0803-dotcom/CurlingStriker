using UnityEngine;

public readonly struct Score
{
	public readonly float Value;
	public const string unit = "m";
	public const float maxValue = 999f;

	// スコアを計算して初期化するコンストラクタ
	public Score(Vector2 stonePosition, Vector2 housePosition)
	{
		Value = Vector2.Distance(stonePosition, housePosition);
		if (Value > maxValue) Value = maxValue;
	}

	// スコア値を直接受け取って初期化するコンストラクタ
	public Score(float value)
	{
		this.Value = value;
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
