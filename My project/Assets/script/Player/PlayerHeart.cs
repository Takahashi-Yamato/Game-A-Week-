using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public PlayerHeartUI heartUI;  // Inspectorでセット

    void Start()
    {
        currentHP = maxHP;
        if (heartUI != null)
            heartUI.SetHP(currentHP); // UI初期化
    }

    public void TakeDamage(int amount = 1)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        if (heartUI != null)
            heartUI.SetHP(currentHP); // UI更新

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("💀 プレイヤー死亡！");
        GameManager.Instance.PlayerDied(); // GameManager に通知
        Destroy(gameObject);
    }
}
