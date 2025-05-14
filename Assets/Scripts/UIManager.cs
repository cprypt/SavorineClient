using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;             // 전환할 UI 패널들
    public Text notificationText;           // 알림 텍스트 UI
    public GameObject notificationPanel;    // 알림이 표시되는 배경 패널

    // 특정 패널만 활성화하고 나머지는 끔
    public void ShowPanel(GameObject target)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        target.SetActive(true);
    }

    // 알림 메시지 표시
    public void AddNotification(string message)
    {
        notificationText.text = message;
        notificationPanel.SetActive(true);
    }

    // 알림 숨기기
    public void HideNotification()
    {
        notificationPanel.SetActive(false);
    }

    //패널 이름으로 찾는 함수
    public GameObject GetPanelByName(string name)
{
    foreach (GameObject panel in panels)
    {
        if (panel.name == name)
            return panel;
    }
    return null;
}

}
