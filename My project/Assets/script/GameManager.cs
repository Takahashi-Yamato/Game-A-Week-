using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTime = 60f; // クリアまでの時間
    private float elapsedTime = 0f;
    private bool isGameOver = false;

    public Text timerText; // Inspectorでセット
   


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (isGameOver) return;

        elapsedTime += Time.deltaTime;

        // Timer表示更新
        if (timerText != null)
        {
            float remaining = Mathf.Max(0f, gameTime - elapsedTime);
            timerText.text = $"Time: {remaining:F1}s";
        }

        if (elapsedTime >= gameTime)
        {
            GameClear();
        }
    }
    public void PlayerDied()
    {
        isGameOver = true;
        SceneManager.LoadScene("GameOverScene");
    }

    void GameClear()
    {
        isGameOver = true;
        SceneManager.LoadScene("ClearScene");
    }

    // GameOverSceneから呼び出せるように
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
