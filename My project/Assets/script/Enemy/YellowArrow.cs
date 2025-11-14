using UnityEngine;

public class YellowArrow : ArrowBase
{
    private bool isCircling = false;
    private bool returningToPlayer = false;
    private float rotatedAngle = 0f;

    protected override void StartArrow()
    {
        SetRotation();
    }

    protected override void UpdateArrow()
    {
        if (player == null) return;

        if (!isCircling && !returningToPlayer)
        {
            // 最初は直進
            MoveForward();

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= 3f) // 半分くらいで円弧開始
            {
                isCircling = true;
                rotatedAngle = 0f;
            }
        }
        else if (isCircling)
        {
            // プレイヤーを中心に回転
            float rotateSpeed = 180f;
            float deltaAngle = rotateSpeed * Time.deltaTime;
            transform.RotateAround(player.position, Vector3.forward, deltaAngle);
            rotatedAngle += deltaAngle;

            if (rotatedAngle >= 180f)
            {
                isCircling = false;
                returningToPlayer = true;
            }
        }
        else if (returningToPlayer)
        {
            // 再突撃
            direction = ((Vector2)(player.position - transform.position)).normalized;
            MoveForward();
        }

        SetRotation();
    }
}
