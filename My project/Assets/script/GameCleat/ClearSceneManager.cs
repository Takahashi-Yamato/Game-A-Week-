using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    // ボタンから呼び出す関数
    public void GoToTitle()
    {
        SceneManager.LoadScene("StartScene"); // タイトルScene名に合わせて変更
    }
}
