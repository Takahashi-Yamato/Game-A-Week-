using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text timeText; // Inspector‚ÅText‚ðƒZƒbƒg

    void Start()
    {
        float survivedTime = GameManager.Instance.GetElapsedTime();
        timeText.text = "‘Ï‚¦‚½ŽžŠÔ: " + survivedTime.ToString("F2") + "•b";
    }
}
