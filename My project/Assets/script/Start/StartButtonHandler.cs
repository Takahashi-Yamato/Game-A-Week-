
using UnityEngine;
using UnityEngine.SceneManagement; // シーン遷移に必要

public class StartButtonHandler : MonoBehaviour
{
    // Inspectorで設定できるようにする
    public string SampleScene = "SampleScene"; // ゲーム本編のシーン名

    // ボタンに設定
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(SampleScene);
    }
}
