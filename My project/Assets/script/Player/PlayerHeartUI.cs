using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartUI : MonoBehaviour
{
    public Image[] hearts; // ハート画像の配列

    public void SetHP(int currentHP)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
