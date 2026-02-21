using UnityEngine;

// OptionPanelの表示状態を切り替える
public class OptionPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionPanel.SetActive(false);
    }

    // 設計パネルを開く
    public void OpenOption()
    {
        optionPanel.SetActive(true);
    }

    // 設計パネルを閉じる
    public void CloseOption()
    {
        optionPanel.SetActive(false);
    }
}
