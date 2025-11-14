using UnityEngine;

public class RedArrow : ArrowBase
{
    protected override void StartArrow()
    {
        SetRotation(); // ‰Šú‰ñ“]
    }

    protected override void UpdateArrow()
    {
        // Ô–î‚Í’¼i‚·‚é‚¾‚¯‚¾‚ªA‘¬“x‚ğ­‚µ‘¬‚ß‚é
        float fastSpeed = speed * 1.5f; // ’Êí‚Ì1.5”{‘¬
        transform.Translate(direction * fastSpeed * Time.deltaTime, Space.World);
    }
}
