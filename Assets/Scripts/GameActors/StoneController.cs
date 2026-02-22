using UnityEngine;
using UnityEngine.InputSystem;

public class StoneController : MonoBehaviour
{
    [SerializeField] private Stone stone;
    private GameReferee referee;

    public void SetReferee(GameReferee referee)
    {
        this.referee = referee;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasAccelerateInput) return;
        if (referee == null || !referee.CanAccelerate()) return;
        stone.TryAccelerate();
    }

    private bool HasAccelerateInput
    {
        get
        {
            // キーボードのスペースキーが押されたか
            bool isSpacePressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;

            // マウスの左クリックが押されたか
            bool isMousePressed = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

            // スマホなどの画面タップ（タッチパネル）が押されたか
            bool isTouched = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

            return isSpacePressed || isMousePressed || isTouched;
        }
    }
}
