using System;
using UnityEngine;

public class HighScoreManager
{
    public static event Action OnHighScoreReset;
    private const string HighScoreKey = "HighScore";
    private const float DefaultHighScore = Score.maxValue;

    // ハイスコアを返す
    public static Score GetHighScore()
    {
        float highScoreValue = PlayerPrefs.GetFloat(HighScoreKey, DefaultHighScore);
        return new Score(highScoreValue);
    }

    // 現在のスコアの方が良いなら、更新する
    public static void UpdateHighScore(Score currentScore)
    {
        Score highScore = GetHighScore();
        if (currentScore.IsBetterThan(highScore))
        {
            PlayerPrefs.SetFloat(HighScoreKey, currentScore.Value);
            PlayerPrefs.Save();
        }
    }

    // ハイスコアをリセットする
    public static void ResetHighScore()
    {
        PlayerPrefs.SetFloat(HighScoreKey, DefaultHighScore);
        PlayerPrefs.Save();
        OnHighScoreReset?.Invoke();
    }
}