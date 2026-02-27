using UnityEngine;

public class Stone : MonoBehaviour
{
    private Rigidbody2D rb;
    private Friction friction;
    [SerializeField] private float accel = 0.4f;
    [SerializeField] private AudioClip pushStoneSE;
    private bool isAccelerating = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        friction = GetComponent<Friction>();
    }

    void FixedUpdate()
    {
        if (isAccelerating)
        {
            Acceleration();
            SoundSpeaker.Instance.PlaySE(pushStoneSE);
            isAccelerating = false;
        }
        rb.linearVelocity = friction.Apply(rb.linearVelocity); // 摩擦力をかける
    }

    // 加速できるなら加速を準備する
    public void TryAccelerate()
    {
        isAccelerating = true;
    }

    // 加速する
    void Acceleration()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x + accel, rb.linearVelocity.y);
    }

    // 停止しているか判定
    public bool IsStopped => rb.linearVelocity == Vector2.zero;

    // 現在のX座標を返す
    public float CurrentX => transform.position.x;
}
