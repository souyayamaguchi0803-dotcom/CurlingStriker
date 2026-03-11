using NUnit.Framework;
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

    void Update()
    {
        if (!HasAccelerateInput) return;
        if (referee == null || !referee.AllowsAcceleration()) return;
        stone.TryAccelerate();
    }

    private bool HasAccelerateInput
    {
        get
        {
            // キーボードのスペースキーが押されたか
            bool isSpacePressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;

            // キーボードのエンターキーが押されたか
            bool isEnterPressed = Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame;

            // マウスの左クリックが押されたか
            bool isMousePressed = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

            // スマホなどの画面タップ（タッチパネル）が押されたか
            bool isTouched = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

            return isSpacePressed || isEnterPressed || isMousePressed || isTouched;
        }
    }
}
