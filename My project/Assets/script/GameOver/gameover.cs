using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
