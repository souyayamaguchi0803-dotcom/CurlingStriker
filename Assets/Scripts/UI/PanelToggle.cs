using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// パネルの表示状態を切り替える
public class PanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject initialSelectedObject;
    [SerializeField] private GameObject closedSelectedObject;

    private bool isEscapePressed => Keyboard.current != null
                                && Keyboard.current.escapeKey.wasPressedThisFrame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        // パネルが開いている状態の時に、ESCキーが押されたら閉じる
        if (panel.activeSelf && isEscapePressed)
        {
            ClosePanel();
        }
    }

    // パネルを開く
    public void OpenPanel()
    {
        panel.SetActive(true);
        FocusSetter.Set(initialSelectedObject);
    }

    // パネルを閉じる
    public void ClosePanel()
    {
        panel.SetActive(false);
        FocusSetter.Set(closedSelectedObject);
    }
}
