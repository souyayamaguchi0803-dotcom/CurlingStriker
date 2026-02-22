using UnityEngine;
using UnityEngine.EventSystems;

// OptionPanelの表示状態を切り替える
public class OptionPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject initialSelectedObject;
    [SerializeField] private GameObject closedSelectedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionPanel.SetActive(false);
    }

    // 設計パネルを開く
    public void OpenOption()
    {
        optionPanel.SetActive(true);

        // フォーカスを合わせる
        EventSystem.current.SetSelectedGameObject(null);
        if (initialSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(initialSelectedObject);
        }
    }

    // 設計パネルを閉じる
    public void CloseOption()
    {
        optionPanel.SetActive(false);

        // フォーカスを合わせる
        EventSystem.current.SetSelectedGameObject(null);
        if (closedSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(closedSelectedObject);
        }
    }
}
