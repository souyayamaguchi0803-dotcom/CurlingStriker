using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;

    void Awake()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        Display();
    }

    // 現在のハイスコアを表示する
    public void Display()
    {
        Score highScore = HighScoreManager.GetHighScore();
        highScoreText.text = $"ハイスコア: {highScore.Show()}";
    }
}