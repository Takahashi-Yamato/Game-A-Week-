using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
    public GameObject shieldUp;
    public GameObject shieldDown;
    public GameObject shieldLeft;
    public GameObject shieldRight;

    private GameObject currentShield;

    void Start()
    {
        // 初期は上方向
        SetShieldDirection(shieldUp);
    }

    void Update()
    {
        // キー入力によって盾の方向を切り替える
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetShieldDirection(shieldUp);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetShieldDirection(shieldDown);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetShieldDirection(shieldLeft);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetShieldDirection(shieldRight);
        }
    }

    void SetShieldDirection(GameObject shield)
    {
        // すべて非表示
        shieldUp.SetActive(false);
        shieldDown.SetActive(false);
        shieldLeft.SetActive(false);
        shieldRight.SetActive(false);

        // 選択した盾だけ表示
        shield.SetActive(true);
        currentShield = shield;
    }

    public GameObject GetCurrentShield()
    {
        return currentShield;
    }
}
