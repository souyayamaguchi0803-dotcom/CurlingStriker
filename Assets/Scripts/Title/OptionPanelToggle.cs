using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// OptionPanelの表示状態を切り替える
public class OptionPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject initialSelectedObject;
    [SerializeField] private GameObject closedSelectedObject;

    private bool PressedEscape => Keyboard.current != null
                                && Keyboard.current.escapeKey.wasPressedThisFrame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optionPanel.SetActive(false);
    }

    void Update()
    {
        // パネルが開いている状態の時に、ESCキーが押されたら閉じる
        if (optionPanel.activeSelf && PressedEscape)
        {
            CloseOption();
        }
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
