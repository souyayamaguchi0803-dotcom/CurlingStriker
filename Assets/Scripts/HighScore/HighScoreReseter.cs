using UnityEngine;

public class HighScoreReseter : MonoBehaviour
{
    // 必要な場合、ハイスコアを描画するクラスへの参照を保持
    [SerializeField] private HighScoreDisplay highScoreDisplay;

    // ハイスコアをリセットする
    public void ResetHighScore()
    {
        HighScoreManager.ResetHighScore();

        // 必要ならハイスコアを再描画
        if (highScoreDisplay != null) highScoreDisplay.Display();
    }
}