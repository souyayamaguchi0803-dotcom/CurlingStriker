using UnityEngine;
using UnityEngine.EventSystems;

// フォーカスの設定を行う静的クラス
public static class FocusSetter
{
    public static void Set(GameObject target)
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (target != null)
        {
            EventSystem.current.SetSelectedGameObject(target);
        }
    }
}
