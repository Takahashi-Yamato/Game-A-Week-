using UnityEngine;

public abstract class ArrowBase : MonoBehaviour
{
    [Header("共通設定")]
    public float speed = 5f;          // 移動速度
    protected Vector2 direction;      // 移動方向
    protected Transform player;       // プレイヤー参照

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        StartArrow();
    }

    protected virtual void Update()
    {
        UpdateArrow();
    }

    // ====== 継承先でオーバーライドする処理 ======
    protected abstract void StartArrow();
    protected abstract void UpdateArrow();

    // ====== 共通メソッド ======
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        SetRotation();
    }

    protected void MoveForward()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    protected void SetRotation()
    {
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle -= 90f; // 矢が上向き前提なら補正
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    // ====== 当たり判定 ======
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHeart heart = other.GetComponent<PlayerHeart>();
            if (heart != null)
            {
                heart.TakeDamage();
            }
            Destroy(gameObject); // インスタンスだけ消す
        }
        else if (other.CompareTag("Shield"))
        {
            Destroy(gameObject); // 盾に当たったら消える
        }
    }
}
