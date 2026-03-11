using UnityEngine;
using UnityEngine.EventSystems;

public class HighScoreResetter : MonoBehaviour
{
    // ハイスコアをリセットする
    public void ResetHighScore()
    {
        HighScoreManager.ResetHighScore();
    }
}