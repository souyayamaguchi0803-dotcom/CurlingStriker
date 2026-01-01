using TMPro;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject house;
    [SerializeField] private GameObject resultUI;
    [SerializeField] private TextMeshProUGUI resultText;

    // ゲーム終了時の処理
    public void EndGame()
    {
        Score score = new Score(stone.transform.position, house.transform.position);
        ShowResult(score);
        HighScoreManager.UpdateHighScore(score);
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
