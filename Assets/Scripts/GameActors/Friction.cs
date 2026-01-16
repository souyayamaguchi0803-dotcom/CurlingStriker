using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Friction : MonoBehaviour
{
    [SerializeField] private float frictionAmount = 0.05f;

    // 摩擦で減速した結果を返す
    public Vector2 Apply(Vector2 velocity)
    {
        float newSpeed = velocity.magnitude - frictionAmount;
        if (newSpeed < 0) return Vector2.zero;
        return velocity.normalized * newSpeed;
    }
}
