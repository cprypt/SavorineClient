using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public UIManager uiManager;

    private GameObject currentPanel;
    private bool isNearHome = false;

    void Update()
    {
        // 상점, 주방, 던전: UI 열기
        if (Input.GetKeyDown(KeyCode.E) && currentPanel != null)
        {
            uiManager.ShowPanel(currentPanel);
            uiManager.HideNotification();
        }

        // 집 입구: 씬 전환
        if (Input.GetKeyDown(KeyCode.E) && isNearHome)
        {
            uiManager.HideNotification();
            SceneManager.LoadScene("HomeInterior"); // 집 내부 씬 이름으로 바꾸기
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shop"))
        {
            currentPanel = uiManager.GetPanelByName("ShopPanel");
            uiManager.AddNotification("E 키를 눌러 상점을 이용하세요");
        }
        else if (other.CompareTag("Cook"))
        {
            currentPanel = uiManager.GetPanelByName("CookPanel");
            uiManager.AddNotification("E 키를 눌러 요리를 시작하세요");
        }
        else if (other.CompareTag("Dungeon"))
        {
            currentPanel = uiManager.GetPanelByName("DungeonModePanel");
            uiManager.AddNotification("E 키를 눌러 던전에 입장하세요");
        }
        else if (other.CompareTag("Home"))
        {
            isNearHome = true;
            uiManager.AddNotification("E 키를 눌러 집에 들어가기");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shop") || other.CompareTag("Cook") || other.CompareTag("Dungeon"))
        {
            currentPanel = null;
            uiManager.HideNotification();
        }
        else if (other.CompareTag("Home"))
        {
            isNearHome = false;
            uiManager.HideNotification();
        }
    }
}
