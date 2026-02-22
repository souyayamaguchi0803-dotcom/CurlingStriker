using UnityEngine;
using UnityEngine.EventSystems;

public class HighScoreReseter : MonoBehaviour
{
    // 必要な場合、ハイスコアを描画するクラスへの参照を保持
    [SerializeField] private HighScoreDisplay highScoreDisplay;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private GameObject initialSelectedObject;
    [SerializeField] private GameObject closedSelectedObject;

    void Start()
    {
        confirmPanel.SetActive(false);
    }

    // 確認パネルを開く
    public void OpenConfirmPanel()
    {
        confirmPanel.SetActive(true);

        // フォーカスを合わせる
        EventSystem.current.SetSelectedGameObject(null);
        if (initialSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(initialSelectedObject);
        }
    }

    // 確認パネルを閉じる
    public void CloseConfirmPanel()
    {
        confirmPanel.SetActive(false);

        // フォーカスを合わせる
        EventSystem.current.SetSelectedGameObject(null);
        if (closedSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(closedSelectedObject);
        }
    }

    // ハイスコアをリセットする
    public void ResetHighScore()
    {
        HighScoreManager.ResetHighScore();

        // 必要ならハイスコアを再描画
        if (highScoreDisplay != null) highScoreDisplay.Display();

        // ポップアップを閉じる
        CloseConfirmPanel();
    }
}