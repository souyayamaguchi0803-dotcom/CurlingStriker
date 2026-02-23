using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameResult : MonoBehaviour
{
    [SerializeField] private ScoreCalculator calculator;
    [SerializeField] private GameObject resultUI;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private GameObject initialSelectedObject;

    // ゲーム終了時の処理
    public void EndGame()
    {
        Score score = calculator.Calculate();
        ShowResult(score);
        HighScoreManager.UpdateHighScore(score);
        FocusSetter.Set(initialSelectedObject);
    }

    // リザルトを表示する
    void ShowResult(Score score)
    {
        resultText.text = $"スコア: {score.Show()}";

        Score highScore = HighScoreManager.GetHighScore();
        if (score.IsBetterThan(highScore))
        {
            resultText.text = "ハイスコア更新！\n" + resultText.text;
        }

        resultUI.SetActive(true);
    }
}
