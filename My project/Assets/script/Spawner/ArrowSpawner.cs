using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject whiteArrowPrefab;
    public GameObject yellowArrowPrefab;
    public GameObject redArrowPrefab;

    public float spawnInterval = 2f;
    public float spawnAcceleration = 0.95f;

    private float timer = 0f;

    // プレイエリアの半径（壁の長さが10なので半径は5）
    private float halfSize = 5f;

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnArrow();
            timer = 0f;

            spawnInterval *= spawnAcceleration;
            if (spawnInterval < 0.3f) spawnInterval = 0.3f;
        }
    }

    void SpawnArrow()
    {
        if (player == null) return;

        Vector2 spawnPos = GetRandomEdgePosition();
        Vector2 dir = (player.position - (Vector3)spawnPos).normalized;

        GameObject arrow;
        float r = Random.value;

        if (r < 0.2f) // 赤矢
        {
            arrow = Instantiate(redArrowPrefab, spawnPos, Quaternion.identity);
            arrow.GetComponent<RedArrow>().SetDirection(dir);
        }
        else if (r < 0.5f) // 黄色矢
        {
            arrow = Instantiate(yellowArrowPrefab, spawnPos, Quaternion.identity);
            arrow.GetComponent<YellowArrow>().SetDirection(dir);
        }
        else // 白矢
        {
            arrow = Instantiate(whiteArrowPrefab, spawnPos, Quaternion.identity);
            arrow.GetComponent<WhiteArrow>().SetDirection(dir);
        }
    }

    Vector2 GetRandomEdgePosition()
    {
        // プレイエリアの半径（壁が±5なので半径は5）
        float halfSize = 5f;

        int side = Random.Range(0, 4);
        Vector2 pos = Vector2.zero;

        switch (side)
        {
            case 0: pos = new Vector2(0, halfSize); break;   // 上（真上）
            case 1: pos = new Vector2(0, -halfSize); break;  // 下（真下）
            case 2: pos = new Vector2(-halfSize, 0); break;  // 左（真左）
            case 3: pos = new Vector2(halfSize, 0); break;   // 右（真右）
        }

        return pos;
    }

}
