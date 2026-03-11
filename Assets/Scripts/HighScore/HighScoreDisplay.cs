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

    // 有効時にイベント購読
    private void OnEnable()
    {
        HighScoreManager.OnHighScoreReset += Display;
    }

    // 無効時はイベント購読を解除
    private void OnDisable()
    {
        HighScoreManager.OnHighScoreReset -= Display;
    }

    // 現在のハイスコアを表示する
    public void Display()
    {
        Score highScore = HighScoreManager.GetHighScore();
        highScoreText.text = $"ハイスコア: {highScore.Show()}";
    }
}