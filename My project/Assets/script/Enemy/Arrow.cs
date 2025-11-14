using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 5f;

    public bool isYellow = false; // 黄色矢印
    public bool isRed = false;    // 赤矢印

    // 黄色矢印用の反転タイマー
    private float reverseTimer = 0f;
    public float reverseDelay = 1.0f; // 1秒後に反転
    private bool reversed = false;

    void Start()
    {
        if (isRed)
        {
            speed *= 1.8f; // 赤矢印は速い
        }

        SetRotation();
    }

    void Update()
    {
        // 黄色矢印の途中反転処理
        if (isYellow && !reversed)
        {
            reverseTimer += Time.deltaTime;
            if (reverseTimer >= reverseDelay)
            {
                direction = -direction; // 逆方向に反転
                reversed = true;
                SetRotation();
            }
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void SetRotation()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f; // 上向き基準
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
