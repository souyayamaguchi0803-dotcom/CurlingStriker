using UnityEngine;

public class Stone : MonoBehaviour
{
    private Rigidbody2D rb;
    private Friction friction;
    [SerializeField] private float accel = 0.4f;
    [SerializeField] private GameObject line;
    private bool isAccelerating = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        friction = GetComponent<Friction>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsOverLine())
        {
            isAccelerating = true;
        }
    }

    void FixedUpdate()
    {
        if (isAccelerating)
        {
            Acceleration();
            isAccelerating = false;
        }
        rb.linearVelocity = friction.Apply(rb.linearVelocity); // 摩擦力をかける
    }

    // 加速する
    void Acceleration()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x + accel, rb.linearVelocity.y);
    }

    // 停止しているか判定
    public bool IsStop()
    {
        return rb.linearVelocity == Vector2.zero;
    }

    // ボーダーラインを超えたか判定
    public bool IsOverLine()
    {
        if (line == null) return false; // lineが未設定の場合falseを返す
        return transform.position.x > line.transform.position.x;
    }
}
